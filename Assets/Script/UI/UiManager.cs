using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	[SerializeField] PanelUI _startGamePanel;
	[SerializeField] PanelUI _resumeGamePanel;
	[SerializeField] PanelUI _winningPanel;

	void Start()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	public void ShowStartGamePanel()
	{
		_startGamePanel.ShowPanel();
	}

	public void ShowResumeGamePanel()
	{
		_resumeGamePanel.ShowPanel();
	}
	public void ShowWinningPanel()
	{
		_winningPanel.ShowPanel();
	}


}
