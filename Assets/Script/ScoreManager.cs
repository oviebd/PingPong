using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	public delegate void OnCheckWinningPoint(GameEnums.Walls nextWallDirection);
	public static event OnCheckWinningPoint CheckWinningPoint;

	public Text scoreText;
	private int scoreRightSidePlayer = 0;
	private int scoreLeftSidePlayer = 0;

	public void Start () {

		if (instance == null)
			instance = this;

		BoundaryBehaviour.updateScoreManagerData += onUpdateScoreManagerData;
	}
	void OnDestroy()
	{
		BoundaryBehaviour.updateScoreManagerData -= onUpdateScoreManagerData;
	}

   void onUpdateScoreManagerData(GameEnums.PlayerEnum scoringPlayer, GameEnums.Walls nextWall)
	{
		UpdateScore(scoringPlayer);
		CheckWinningPoint(nextWall);
	}
	public void UpdateScore(GameEnums.PlayerEnum player)
	{
		if (player == GameEnums.PlayerEnum.Player1_Right)
			scoreRightSidePlayer = scoreRightSidePlayer + 1;
		else if (player == GameEnums.PlayerEnum.Player2_Left)
			scoreLeftSidePlayer = scoreLeftSidePlayer + 1;

		showScoreText();
	}
	void showScoreText()
	{
		string scoreSTring = scoreLeftSidePlayer  + " - " + scoreRightSidePlayer;
		scoreText.text = scoreSTring;
	}

	public void ResetScore()
	{
		scoreLeftSidePlayer =  0;
		scoreRightSidePlayer = 0;
		showScoreText();
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
