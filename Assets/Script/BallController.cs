using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public static BallController instance;

	[SerializeField] private GameObject _ballPrefab;
	[SerializeField] private GameObject _ballParent;

	private GameObject _currentBall;
	void Start()
	{
		if (instance == null)
			instance = this;

	    InstantiateBall();
	}

	public void ResetBall()
	{
		if (_currentBall != null)
		{
			_currentBall.GetComponent<BallMovement>().ResetPosition();
		}
	}

	public GameObject InstantiateBall()
	{
	   Ball ball = GenerateBall(GameEnums.ballType.type1);
	  GameObject ballObject = InstantiatorHelper.InstantiateObject(_ballPrefab, _ballParent);
	  ballObject.GetComponent<BallMovement>().setBall(ball);
		_currentBall = ballObject;
	 return ballObject;
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

		return ball.getBall();
	}
	
	/*public void DestroyBall()
	{
		if(this._currentBall !=null)
		{
			this._currentBall.StopMove();
			Destroy(this._currentBall.gameObject);
			this._currentBall = null;
		}
	}*/

}
