using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameDataScriptable : ScriptableObject
{
	public bool isGameFirstPlayed = true;
	public int currentLevelNumber = 1;
	public int maximumNumberOfLevelCompletedByUser = 1;
	public int amountOfLife = 0;
	public int bestScore = 0;
}
