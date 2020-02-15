using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningUIPanel : PanelUI {

	[SerializeField] private Text _congratesText;
	[SerializeField] private Text _playerGameStatus;
	[SerializeField] private GameObject _retryButtonObj;
	[SerializeField] private GameObject _nextButtonObj;


	public void SetWinningPanel(bool isWin)
	{
		if(isWin)
		{
			_congratesText.text = "Congratulations";
			_playerGameStatus.text = "Play Level " + GameLevelDataHandler.instance.GetLevel() + 1 ;
			_retryButtonObj.SetActive(false);
			_nextButtonObj.SetActive(true);
		}
		else
		{
			_congratesText.text = "Try Harder";
			_playerGameStatus.text = "You Loose";
			_retryButtonObj.SetActive(true);
			_nextButtonObj.SetActive(false);
		}
	}
	
}
