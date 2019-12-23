using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	[SerializeField] private GameObject _ballPrefab;
	[SerializeField] private GameObject _ballParent;
	
	void Start()
	{
	   InstantiateBall();
	}

	public GameObject InstantiateBall()
	{
	   Ball ball = GenerateBall(GameEnums.ballType.type1);
	   GameObject ballObj = InstantiatorHelper.InstantiateObject(_ballPrefab, _ballParent);
	   ballObj.GetComponent<BallMovement>().setBall(ball);
	   return ballObj;
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
}
