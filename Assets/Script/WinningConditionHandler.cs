using System.Collections;
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
	public void SetWinningPoint(int winningPoint)
	{
		this._winningPoint = winningPoint;
		//this._winningPoint = 100;
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
			Debug.Log("Lost game in winning condition");
			//GameManager.instance.LoadNextLevel();
			GameManager.instance.GameOver(true);
		}
	}

}
