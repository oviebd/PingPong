using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Paddle leftPaddle;
    public Paddle rightPaddle;
    public Ball ball;

    // Use this for initialization
	void Start () {
		BoundaryController.BallCollisionWithLeftRightWall += BallCollisionWithLeftRightWall;
	}

	public void BallCollisionWithLeftRightWall(GameEnums.PlayerEnum winnerPlayer)
	{
		Debug.Log("Winner Player is ': " + winnerPlayer);
	}



}
