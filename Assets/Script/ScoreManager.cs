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

		//ResetScore();
		ObstacleBehaviour.updateScoreManagerData += onUpdateScoreManagerData;
	}
	void OnDestroy()
	{
		ObstacleBehaviour.updateScoreManagerData -= onUpdateScoreManagerData;
	}

   void onUpdateScoreManagerData(int updatedScore)
	{
		//Debug.Log("Current Score : " + currentScore + "  Updated Score : " + updatedScore);
		currentScore = currentScore + updatedScore;
		showScoreText();
		WinningConditionHandler.instance.CheckWinningPoint();
	}
	
	void showScoreText()
	{
		string scoreSTring = currentScore  + " / " + WinningConditionHandler.instance.GetWinningPoint() ;
	//	string scoreSTring = currentScore + " / ";
		scoreText.text = scoreSTring;
	}

	public void ResetScore()
	{
		currentScore =  0;
		showScoreText();
	}

	public  int GetCurrentScore()
	{
		return currentScore;
	}
}
