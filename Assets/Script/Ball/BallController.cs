using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public static BallController instance;

	[SerializeField] private GameObject _ballPrefab;
	[SerializeField] private GameObject _ballParent;

	private GameObject _currentBall;
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

	public GameObject InstantiateBall()
	{

	    Ball ball = GenerateBall(GameEnums.ballType.type1);
	    GameObject ballObject = InstantiatorHelper.InstantiateObject(_ballPrefab, _ballParent);

        BallBehaviour ballBehaviour = ballObject.GetComponent<BallBehaviour>();
        ballBehaviour.setBall(ball);
        
        if(_currentBall == null)
            _currentBall = ballObject;
        else
        {
           // StartCoroutine(setMovement(ballMovement));
            _additionalBalls.Add(ballBehaviour);
        }
	  return ballObject;
	}


    IEnumerator setMovement(BallMovement movement)
    {
        yield return new WaitForSeconds(0.5f);
        movement.StartBallMovement();
    }

	Ball GenerateBall(GameEnums.ballType ballType)
	{
		BallBuilder builder = new BallBuilder();
		IBallBuilder ball;
		if(ballType == GameEnums.ballType.type1)
			ball = new Type1Ball();
		else
			ball = new Type1Ball();

		builder.BuildBallBall(ball);
		ball.SetColor(Color.green);

        if (_currentBall == null)
            ball.getBall().isItFirstBall = true;

        return ball.getBall();
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
            if(_additionalBalls[i].GetBall().ballType == GameEnums.ballType.type1)
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

}
