using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameDataGeneratorHandler
{
	public static int  GenerateObstacleBasedOnLevelNumber()
	{
		int levelNo = GameLevelDataHandler.instance.GetLevel() - 1 ;

		int maxObstacle = 150;
		int startingObstacleNumber = 40;
		int increaseObstaclePerLevel = 10 ;

		int calculatedObstacleNumber= startingObstacleNumber + (increaseObstaclePerLevel * levelNo);
		if (calculatedObstacleNumber > maxObstacle)
			calculatedObstacleNumber = maxObstacle;

		return calculatedObstacleNumber;
	}
}
