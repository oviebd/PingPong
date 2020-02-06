using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelDataHandler : MonoBehaviour
{
	public static GameLevelDataHandler instance;

	int currentLevel = 1;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void AddLevel()
	{
		currentLevel = currentLevel + 1;
	}

	public void ResetLevel()
	{
		currentLevel = 1;
	}
	public int GetLevel()
	{
		return currentLevel;
	}

}
