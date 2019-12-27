using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningConditionHandler : MonoBehaviour {

	public WinningConditionHandler instance;
	private int _winningPoint = 3;


	void Start()
	{
		if (instance == null)
			instance = new WinningConditionHandler();
	}

	public void SetWinningPoint(int winningPoint)
	{
		this._winningPoint = winningPoint;
	}

	void CheckWinningPoint()
	{
		if (ScoreManager.instance.GetRightSidePlayerScore() >= _winningPoint)
		{
			PlayerWin(GameEnums.PlayerEnum.Player1_Right);
		}
		if (ScoreManager.instance.GetLeftSidePlayerScore() >= _winningPoint)
		{
			PlayerWin(GameEnums.PlayerEnum.Player2_Left);
		}
	}

	void PlayerWin(GameEnums.PlayerEnum winnerPlayer)
	{

	}
}
