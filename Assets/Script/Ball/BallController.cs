﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public static BallController instance;

	[SerializeField] private GameObject _ballPrefab;
	[SerializeField] private GameObject _ballParent;

	private GameObject _currentBall;
    [SerializeField] private List<GameObject> _ballPrefabList;
    private  List<BallBehaviour> _additionalBalls = new List<BallBehaviour>(); 

	void Start()
	{
		if (instance == null)
			instance = this;

        BoundaryBehaviour.onBallCollideWithLeftRightWall += onBallCollidedWithLeftRightWall;

      //  InvokeRepeating("InstantiateBall", 5.0f, 8.0f);
    }

	public void ResetBall(GameEnums.Walls nextWallDirection)
	{
		if (_currentBall != null)
		{
			_currentBall.GetComponent<BallMovement>().ResetPosition(nextWallDirection);
		}
	}

	public void PrepareBallControllerForNewGame()
	{
		DestroyAllExistingBalls();
		InstantiateBall(GameEnums.ballType.NormalBall_Type1);
	}
	public GameObject InstantiateBall(GameEnums.ballType ballType)
	{
        //Debug.Log("Instantiate ball of type " + ballType);
        GameObject ball = GetSpecificBall(GameEnums.ballType.NormalBall_Type1);
	    GameObject ballObject = InstantiatorHelper.InstantiateObject(ball, _ballParent);

        BallBehaviour ballBehaviour = ballObject.GetComponent<BallBehaviour>();
        ballBehaviour.SetUp();
        
        if(_currentBall == null)
            _currentBall = ballObject;
        else
        {
            StartCoroutine(setMovement(ballBehaviour.GetBallMovement()));
            _additionalBalls.Add(ballBehaviour);
        }
	  return ballObject;
	}


    IEnumerator setMovement(BallMovement movement)
    {
        yield return new WaitForSeconds(0.5f);
        movement.StartBallMovement();
    }

    GameObject GetSpecificBall(GameEnums.ballType type)
    {
        for (int i = 0; i < _ballPrefabList.Count; i++)
        {
            BallBehaviour ball = _ballPrefabList[i].GetComponent<BallBehaviour>();
            if (ball != null && type == ball.ballType)
                return _ballPrefabList[i];
        }
        return null;
    }
   


    void SetFirstAndSpecialBall()
    {
        BallBehaviour ballBehaviour = GetTopBallForMadeBasicBall();
        if (ballBehaviour != null)
            _currentBall = ballBehaviour.gameObject;
    }

    BallBehaviour GetTopBallForMadeBasicBall()
    {
        for(int i=0;i< _additionalBalls.Count; i++)
        {
            if(_additionalBalls[i].GetBall().ballType == GameEnums.ballType.NormalBall_Type1)
            {
                BallBehaviour tempBallBehaviour = _additionalBalls[i];
                _additionalBalls.RemoveAt(i);

                Ball  updatedBall = tempBallBehaviour.GetBall();
                updatedBall.isItFirstBall = true;

                tempBallBehaviour.UpdateBall(updatedBall);
                return tempBallBehaviour;
            }
        }
        return null;
    }

    public void onBallCollidedWithLeftRightWall(GameEnums.Walls nextWall,GameObject ballObject)
    {
        _currentBall = null;
        SetFirstAndSpecialBall();

        if (_currentBall == null)
        {
            GameLifeHandler.instance.onBallCollidedWithLeftRightWall(nextWall);
           // GameManager.instance.GameOver(false);  // LoseGame
        }
        else
        {
            Destroy(ballObject);
        }
    }

	public void DestroyAllExistingBalls()
	{
		for(int i = 0;i< _additionalBalls.Count; i++)
		{
			Destroy(_additionalBalls[i].gameObject);
		}
		_additionalBalls.Clear();
	}

}
