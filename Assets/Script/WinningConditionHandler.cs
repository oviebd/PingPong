using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningConditionHandler : MonoBehaviour {

	public static WinningConditionHandler instance;
	private int _winningPoint = 3;

	public delegate void onNotifuGameManagerForBallCollisionOnLeftRightWall(bool isWinning, GameEnums.PlayerEnum winnerPlayer, GameEnums.Walls collidedWall);
	public static event onNotifuGameManagerForBallCollisionOnLeftRightWall notifyGameManagerForBallCollisionOnLeftRightWall;

	void Start()
	{
		if (instance == null)
			instance = new WinningConditionHandler();

		ScoreManager.CheckWinningPoint += CheckWinningPoint;
	}

	public void SetWinningPoint(int winningPoint)
	{
		this._winningPoint = winningPoint;
	}

	public void CheckWinningPoint()
	{
		if (ScoreManager.instance.GetRightSidePlayerScore() >= _winningPoint)
		{
			PlayerWin(GameEnums.PlayerEnum.Player1_Right);
		}
		else if (ScoreManager.instance.GetLeftSidePlayerScore() >= _winningPoint)
		{
			PlayerWin(GameEnums.PlayerEnum.Player2_Left);
		}
		else
			notifyGameManagerForBallCollisionOnLeftRightWall(false, GameEnums.PlayerEnum.Player1_Right, GameEnums.Walls.left); //As it is not winning sisuation so wall is important but player is not
	}

	void PlayerWin(GameEnums.PlayerEnum winnerPlayer)
	{
		notifyGameManagerForBallCollisionOnLeftRightWall(true, winnerPlayer, GameEnums.Walls.left); //As  player wins wall doesnot matter but player is important
	}

}
