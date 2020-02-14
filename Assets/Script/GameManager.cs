using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	private GameEnums.GameState _gameCurrentState;

	public delegate void onGameStateChanged(GameEnums.GameState gameState);
	public static event onGameStateChanged gameStateChanged;

	void Start () {
		_gameCurrentState = GameEnums.GameState.Idle;

		if (instance == null)
			instance = this;

		CountTextAnimation.OnCountAnimationFinished += onCountAnimationCompleted;
		//PrepapreGameStage.instance.PrepareNewGame();

	}

	void OnDestroy()
	{
   		CountTextAnimation.OnCountAnimationFinished -= onCountAnimationCompleted;
	}

	public GameEnums.GameState GetCurrentGameState()
	{
		return _gameCurrentState;
	}

	public void SetCurrentGameState(GameEnums.GameState gameState)
	{
		_gameCurrentState = gameState;
        if (gameStateChanged != null) {
			gameStateChanged(gameState);
		}
	}
	void onCountAnimationCompleted()
	{
        switch (_gameCurrentState)
        {
			case GameEnums.GameState.NewGame:
				PrepapreGameStage.instance.PrepareNewGame();
				break;
			case GameEnums.GameState.LevelUp:
				PrepapreGameStage.instance.PrepareLevelUp();
				break;
			case GameEnums.GameState.Resume:
				PrepapreGameStage.instance.PrepareResumeGame();
				break;
			case GameEnums.GameState.Revive:
				PrepapreGameStage.instance.PrepareReviveGame();
				break;
		}
	}

	public void GameOver(bool isWin)
	{
		BallController.instance.DestroyAllExistingBalls();
		SetCurrentGameState (GameEnums.GameState.Over);
		GameSceneUIManager.instance.SetGameOverUI(isWin);
	}

	public void StartANewGame()
	{
		SetCurrentGameState(GameEnums.GameState.NewGame);
		GameSceneAnimationHandler.instance.PlayCountAnimation(3);
	}
	public void PauseGame()
	{
		SetCurrentGameState(GameEnums.GameState.Pause);
		GameSceneUIManager.instance.SetUiForPauseGame();
	}
	public void ResumeGame()
	{
		GameSceneUIManager.instance.SetUiForResumeGame();
		SetCurrentGameState(GameEnums.GameState.Running);
	}
	public void LoadNextLevel()
	{
		SetCurrentGameState(GameEnums.GameState.LevelUp);
		GameSceneAnimationHandler.instance.PlayCountAnimation(3);
	}
	public void ReviveGame()
	{
		SetCurrentGameState(GameEnums.GameState.Revive);
		GameSceneAnimationHandler.instance.PlayCountAnimation(2);
	}

}
