using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUIManager : MonoBehaviour {

	public static GameSceneUIManager instance;

	[SerializeField] private PanelUI _startGamePanel;
	[SerializeField] private WinningUIPanel _winningPanel;
	[SerializeField] private GameObject _resumeButton;
	[SerializeField] private GameObject _pauseButtonObj;
	[SerializeField] private GameObject _inputGamePanel;
	[SerializeField] private GameObject _rootGameUiPanel;
	[SerializeField] private GameObject _lifeUiPanel;

	void Start()
	{
		if(instance == null)
		{
			instance = this;
		}
		InitialGameUI();
	}

	public void InitialGameUI()
	{
		HideAllPanel();
		_startGamePanel.ShowPanel();
		/*_resumeButton.SetActive(false);
		_pauseButtonObj.SetActive(false);
		_inputGamePanel.SetActive(false);
		_winningPanel.HidePanel();*/
	}

	public void SetUiForANewGame()
	{
		HideAllPanel();
		/*_startGamePanel.HidePanel();
		_winningPanel.HidePanel();
		_resumeButton.SetActive(false);*/
		_pauseButtonObj.SetActive(true);
		_inputGamePanel.SetActive(true);
	}
	public void SetUiForPauseGame()
	{
		HideAllPanel();
		_startGamePanel.ShowPanel();
		_resumeButton.SetActive(true);
		//_pauseButtonObj.SetActive(false);
//		_inputGamePanel.SetActive(false);
	}
	public void SetUiForResumeGame()
	{
		SetUiForANewGame();
	}

	public void SetGameOverUI(bool isWin)
	{
		_winningPanel.ShowPanel();
		_winningPanel.SetWinningPanel(isWin);
	}

    public void ShowHideAllGameUi(bool isShow)
    {
		_rootGameUiPanel.SetActive(isShow);
    }
	public void ShowLifePanelUI()
	{
		HideAllPanel();
		_lifeUiPanel.SetActive(true);
	}

	void HideAllPanel()
	{
		_startGamePanel.HidePanel();
		_winningPanel.HidePanel();
		_resumeButton.SetActive(false);
		_pauseButtonObj.SetActive(false);
		_inputGamePanel.SetActive(false);
		_lifeUiPanel.SetActive(false);

	}

}
