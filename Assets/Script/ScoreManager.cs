using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	public Text scoreText;
	private int currentScore;

	public void Start () {
	
		if (instance == null)
			instance = this;
	}

   public void updateScoreManagerData(int updatedScore)
	{
		currentScore = currentScore + updatedScore;
		UpdateScoreUI();
		WinningConditionHandler.instance.CheckWinningPoint();
	}
	
	public void UpdateScoreUI()
	{
		string scoreSTring = currentScore  + " / " + WinningConditionHandler.instance.GetWinningPoint() ;
		scoreText.text = scoreSTring;
	}

	public void ResetScore()
	{
		currentScore =  0;
		UpdateScoreUI();
	}

	public  int GetCurrentScore()
	{
		return currentScore;
	}
}
