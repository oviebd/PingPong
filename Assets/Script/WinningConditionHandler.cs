﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningConditionHandler : MonoBehaviour {

	public static WinningConditionHandler instance;
	private int _winningPoint = 80;

	void Start()
	{
		if (instance == null)
			instance = this;
	}
	public void SetWinningPoint(int winningPoint)
	{
		this._winningPoint = winningPoint;
		ScoreManager.instance.UpdateScoreUI();
	}

	public int GetWinningPoint()
	{
		return _winningPoint;
	}

	public void CheckWinningPoint()
	{
		if (ScoreManager.instance.GetCurrentScore() >= _winningPoint)
		{
			//Win game
			GameManager.instance.GameOver(true);
		}
	}

}
