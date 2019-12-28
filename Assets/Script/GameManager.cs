using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Start () {

		if (instance == null)
			instance = new GameManager();

		WinningConditionHandler.notifyGameManagerForBallCollisionOnLeftRightWall += NotifyGameManagerForBallCollisionOnLeftRightWall;
	}

	public void RespawnBall()
	{
		//BallController.instance.InstantiateBall();
	}
    void	NotifyGameManagerForBallCollisionOnLeftRightWall(bool isWinning, GameEnums.PlayerEnum winnerPlayer, GameEnums.Walls collidedWall)
	{
		//Debug.Log("Is Player WIn ; " + isWinning);
		if (isWinning)
			playerWin(winnerPlayer);
		else
			BallController.instance.ResetBall();
	}

	void playerWin(GameEnums.PlayerEnum winnerPlayer)
	{

	}






}
