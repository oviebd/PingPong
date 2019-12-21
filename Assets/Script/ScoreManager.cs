using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	private int scorePlayerOne = 0;
	private int scorePlayerTwo = 0;

	public void Start () {
		Paddle.scoreUpdate += UpdateScore;
	}

	public void UpdateScore(GameEnums.PlayerEnum player)
	{
		if (player == GameEnums.PlayerEnum.Player1_Right)
			scorePlayerOne = scorePlayerOne + 1;
		else if (player == GameEnums.PlayerEnum.Player2_Left)
			scorePlayerTwo = scorePlayerTwo + 1;

		showScoreText();
	}

	void showScoreText()
	{
		string scoreSTring = scorePlayerTwo  + " - " + scorePlayerOne;
		scoreText.text = scoreSTring;
	}

}
