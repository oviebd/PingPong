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

		if (gameStateChanged != null)
			gameStateChanged(gameState);

	}
	public void ResetBallOnADirection(GameEnums.Walls nextWallDirection)
	{
			SetCurrentGameState(GameEnums.GameState.Idle);
			BallController.instance.ResetBall(nextWallDirection);
			GameSceneAnimationHandler.instance.PlayCountAnimation(2);
	}

	void onCountAnimationCompleted()
	{
		SetCurrentGameState(GameEnums.GameState.Running);
	}

	public void GameOver(bool isWin)
	{
		SetCurrentGameState (GameEnums.GameState.Over);
		GameSceneUIManager.instance.SetGameOverUI(isWin);
	}

	public void StartANewGame()
	{
		ScoreManager.instance.ResetScore();
		BallController.instance.InstantiateBall();
		GameSceneAnimationHandler.instance.PlayCountAnimation(3);
		GameSceneUIManager.instance.SetUiForANewGame();
	}
	public void PauseGame()
	{
		SetCurrentGameState(GameEnums.GameState.Pause);
		GameSceneUIManager.instance.SetUiForPauseGame();
	}
	public void ResumeGame()
	{
		GameSceneAnimationHandler.instance.PlayCountAnimation(2);
		GameSceneUIManager.instance.SetUiForResumeGame();
	}

}
