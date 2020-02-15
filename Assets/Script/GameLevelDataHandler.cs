using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelDataHandler : MonoBehaviour
{
	public static GameLevelDataHandler instance;
	[SerializeField] private Text _levelNumberText_top;

	private int _currentLevel = 1;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	private void Start()
	{
		_currentLevel = GameDataHandler.instance.GetCurrentLevel();
		UpdateLevelText();
	}

	public void AddLevel()
	{
		_currentLevel = _currentLevel + 1;
		OnLevelDataChanged();
		GameDataHandler.instance.SetMaximumLevelCompletedByPlayer(_currentLevel);
	}

	public void ResetLevel()
	{
		_currentLevel = 1;
		OnLevelDataChanged();
	}
	public int GetLevel()
	{
		return _currentLevel;
	}

	void OnLevelDataChanged()
	{
		UpdateLevelText();
		GameDataHandler.instance.setCurrentGameLevel(_currentLevel);
	}
	public void UpdateLevelText()
	{
		_levelNumberText_top.text = _currentLevel + " ";
	}


}
