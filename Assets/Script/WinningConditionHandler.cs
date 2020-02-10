﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningConditionHandler : MonoBehaviour {

	public static WinningConditionHandler instance;
	private int _winningPoint = 80;

	void Start()
	{
		if (instance == null)
			instance = new WinningConditionHandler();
	}

	void OnDestroy()
	{
	}

	public void SetWinningPoint(int winningPoint)
	{
		this._winningPoint = winningPoint;
	}

	public int GetWinningPoint()
	{
		return _winningPoint;
	}

	public void CheckWinningPoint()
	{
		if (ScoreManager.instance.GetCurrentScore() >= _winningPoint)
		{
			GameManager.instance.GameOver(true);
		}
	}

}
