using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	 
	public void Start () {
		Paddle.scoreUpdate += UpdateScore;
	}

	public void UpdateScore()
	{
		Debug.Log("Score Updated ............");
	}

}
