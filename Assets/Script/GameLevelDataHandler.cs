using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelDataHandler : MonoBehaviour
{
	public static GameLevelDataHandler instance;

	private int _currentLevel = 1;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	private void Start()
	{
		_currentLevel = GameDataHandler.instance.GetCurrentLevel();
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
		GameDataHandler.instance.setCurrentGameLevel(_currentLevel);
	}

}
