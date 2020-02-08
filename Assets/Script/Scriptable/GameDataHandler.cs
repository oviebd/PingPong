using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataHandler : MonoBehaviour
{
	public static GameDataHandler instance;

	[SerializeField] private GameDataScriptable gameData;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public int GetCurrentLevel()
	{
		if (gameData != null)
			return gameData.currentLevelNumber;
		return 1;
	}
	public void setCurrentGameLevel(int levelNo)
	{
		if (gameData != null)
			 gameData.currentLevelNumber =levelNo ;
	}

	public int GetMaximumLevelCompletedByPlayer()
	{
		if (gameData != null)
			return gameData.maximumNumberOfLevelCompletedByUser;
		return 1;
	}
	public void SetMaximumLevelCompletedByPlayer(int levelNo)
	{
		if (gameData != null)
		{
			if(GetMaximumLevelCompletedByPlayer() < levelNo)
				gameData.maximumNumberOfLevelCompletedByUser = levelNo;
		}
		
	}

	public int GetAmountOfLife()
	{
		if (gameData != null)
			return gameData.amountOfLife;
		return 0;
	}
	public void SetAmountOfLife(int lifeNumber)
	{
		if (gameData != null)
			gameData.amountOfLife = lifeNumber;
	}


}
