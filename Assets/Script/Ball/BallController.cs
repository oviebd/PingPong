using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public static BallController instance;

	[SerializeField] private GameObject _ballParent;

    [SerializeField] private List<GameObject> _ballPrefabList;
    private  List<BallBehaviour> _inGameNormalBalls = new List<BallBehaviour>();
	private List<BallBehaviour> _inGameSpecialBalls = new List<BallBehaviour>();

	void Start()
	{
		if (instance == null)
			instance = this;
        BoundaryBehaviour.onBallCollideWithLeftRightWall += onBallCollidedWithLeftRightWall;
      //  InvokeRepeating("InstantiateBall", 5.0f, 8.0f);
    }

	public void InstantiateExtraBall(GameEnums.ballType ballType)
	{
		BallBehaviour behaviour = InstantiateBall(ballType);
		if (behaviour == null)
			return;

		StartCoroutine(setMovement(behaviour.GetBallMovement()));
	}

	public void PrepareBallControllerForNewGame()
	{
		DestroyAllExistingBalls();
		InstantiateBall(GameEnums.ballType.NormalBall_Type1);
	}
	public BallBehaviour InstantiateBall(GameEnums.ballType ballType)
	{
        GameObject ball = GetSpecificBall(ballType);
		if (ball == null)
			return null;
	    GameObject ballObject = InstantiatorHelper.InstantiateObject(ball, _ballParent);

        BallBehaviour ballBehaviour = ballObject.GetComponent<BallBehaviour>();
        ballBehaviour.SetUp();
	   AddBallsInList(ballBehaviour);
	   return ballBehaviour;
	}

	void AddBallsInList(BallBehaviour behaviour)
	{
		if (behaviour.ballType == GameEnums.ballType.NormalBall_Type1)
			_inGameNormalBalls.Add(behaviour);
		else
			_inGameSpecialBalls.Add(behaviour);
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
    public void onBallCollidedWithLeftRightWall(GameEnums.Walls nextWall,GameObject ballObject)
    {
	    BallBehaviour collidedBallBehaviour =	ballObject.GetComponent<BallBehaviour>();
		_inGameNormalBalls.Remove(collidedBallBehaviour);
		Destroy(ballObject);

		if( _inGameNormalBalls.Count <= 0)
			GameLifeHandler.instance.onBallCollidedWithLeftRightWall(nextWall);
    }

	public void DestroyAllExistingBalls()
	{
		BallBehaviour[] behaviours = FindObjectsOfType<BallBehaviour>();
		for (int i = 0; i < behaviours.Length; i++)
		{
				Destroy(behaviours[i].gameObject);
		}
		/*for(int i = 0;i< _inGameNormalBalls.Count; i++)
		{
			if (_inGameNormalBalls[i].gameObject !=null)
				Destroy(_inGameNormalBalls[i].gameObject);
		}
		for (int i = 0; i < _inGameSpecialBalls.Count; i++)
		{
			if(_inGameSpecialBalls[i].gameObject != null)
				Destroy(_inGameSpecialBalls[i].gameObject);
		}
		_inGameNormalBalls = new List<BallBehaviour>();
		_inGameSpecialBalls = new List<BallBehaviour>();*/

		_inGameNormalBalls.Clear();
		_inGameSpecialBalls.Clear();
	}

}
