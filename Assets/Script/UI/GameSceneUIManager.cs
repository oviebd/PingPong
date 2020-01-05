﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUIManager : MonoBehaviour {

	public static GameSceneUIManager instance;

	[SerializeField] private PanelUI _startGamePanel;
	[SerializeField] private PanelUI _winningPanel;
	[SerializeField] private GameObject _resumeButton;
	[SerializeField] private GameObject _pauseButtonObj;

	void Start()
	{
		if(instance == null)
		{
			instance = this;
		}
		InitialGameUI();
	}

	public void InitialGameUI()
	{
		_startGamePanel.ShowPanel();
		_resumeButton.SetActive(false);
		_pauseButtonObj.SetActive(false);
	}

	public void SetUiForANewGame()
	{
		_startGamePanel.HidePanel();
		_resumeButton.SetActive(false);
		_pauseButtonObj.SetActive(true);
	}
	public void SetUiForPauseGame()
	{
		_startGamePanel.ShowPanel();
		_resumeButton.SetActive(true);
		_pauseButtonObj.SetActive(false);
	}
	public void SetUiForResumeGame()
	{
		SetUiForANewGame();
	}

}
