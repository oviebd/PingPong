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

	void OnDestroy()
	{
		WinningConditionHandler.notifyGameManagerForBallCollisionOnLeftRightWall -= NotifyGameManagerForBallCollisionOnLeftRightWall;
	}

	void	NotifyGameManagerForBallCollisionOnLeftRightWall(bool isWinning, GameEnums.PlayerEnum winnerPlayer, GameEnums.Walls nextWallDirection)
	{
		// Debug.Log("Next Wall " + nextWallDirection);
		if (isWinning)
			playerWin(winnerPlayer);
		else
			BallController.instance.ResetBall(nextWallDirection);
	}

	void playerWin(GameEnums.PlayerEnum winnerPlayer)
	{

	}

}
