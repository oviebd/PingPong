using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAndPauseUIPanel : PanelUI {

	public void NewGameButtonClicked()
	{
		GameManager.instance.SetCurrentGameState(GameEnums.GameState.Running);
		HidePanel();
	}

	public void ExitButtonClicked()
	{
		HidePanel();
	}



}
