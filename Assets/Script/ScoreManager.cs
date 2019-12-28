using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	public delegate void OnCheckWinningPoint();
	public static event OnCheckWinningPoint CheckWinningPoint;

	public Text scoreText;
	private int scoreRightSidePlayer = 0;
	private int scoreLeftSidePlayer = 0;

	public void Start () {

		if (instance == null)
			instance = new ScoreManager();

		BoundaryController.updateScoreManagerData += onUpdateScoreManagerData;
	}

	public void onUpdateScoreManagerData(GameEnums.PlayerEnum scoringPlayer, GameEnums.Walls nextWall)
	{
		UpdateScore(scoringPlayer);
	}
	public void UpdateScore(GameEnums.PlayerEnum player)
	{
		if (player == GameEnums.PlayerEnum.Player1_Right)
			scoreRightSidePlayer = scoreRightSidePlayer + 1;
		else if (player == GameEnums.PlayerEnum.Player2_Left)
			scoreLeftSidePlayer = scoreLeftSidePlayer + 1;

		showScoreText();
		CheckWinningPoint();

	}


	void showScoreText()
	{
		string scoreSTring = scoreLeftSidePlayer  + " - " + scoreRightSidePlayer;
		scoreText.text = scoreSTring;
	}

	public  int GetRightSidePlayerScore()
	{
		return scoreRightSidePlayer;
	}
	public int GetLeftSidePlayerScore()
	{
		return scoreLeftSidePlayer;
	}

}
