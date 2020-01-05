using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningUIPanel : PanelUI {

	[SerializeField] private Text _congratesText;
	[SerializeField] private Text _playerGameStatus;


	public void SetWinningPanel(GameEnums.PlayerEnum winningPlayer)
	{
		if(winningPlayer == GameEnums.PlayerEnum.Player1_Right)
		{
			_congratesText.text = "Congratulations";
			_playerGameStatus.text = "You win";
		}
		else
		{
			_congratesText.text = "Try Harder";
			_playerGameStatus.text = "You Loose";
		}
	}
	
}
