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
		WinningConditionHandler.notifyGameManagerForBallCollisionOnLeftRightWall += NotifyGameManagerForBallCollisionOnLeftRightWall;
		CountTextAnimation.OnCountAnimationFinished += onCountAnimationCompleted;
	}

	void OnDestroy()
	{
		WinningConditionHandler.notifyGameManagerForBallCollisionOnLeftRightWall -= NotifyGameManagerForBallCollisionOnLeftRightWall;
		CountTextAnimation.OnCountAnimationFinished -= onCountAnimationCompleted;
	}

	public GameEnums.GameState GetCurrentGameState()
	{
		return _gameCurrentState;
	}
	public void SetCurrentGameState(GameEnums.GameState gameState)
	{
		//Debug.Log("Set Game State .... " + gameState);
		_gameCurrentState = gameState;

		if (gameStateChanged != null)
			gameStateChanged(gameState);

	}

	void	NotifyGameManagerForBallCollisionOnLeftRightWall(bool isWinning, GameEnums.PlayerEnum winnerPlayer, GameEnums.Walls nextWallDirection)
	{
		if (isWinning)
			playerWin(winnerPlayer);
		else
		{
			SetCurrentGameState(GameEnums.GameState.Idle);
			BallController.instance.ResetBall(nextWallDirection);
			GameSceneAnimationHandler.instance.PlayCountAnimation(2);
		}
			
	}

	void onCountAnimationCompleted()
	{
		SetCurrentGameState(GameEnums.GameState.Running);
	}

	void playerWin(GameEnums.PlayerEnum winnerPlayer)
	{
		SetCurrentGameState (GameEnums.GameState.Over);
		GameSceneUIManager.instance.SetUiForWinningPanel(winnerPlayer);
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
	    //SetCurrentGameState(GameEnums.GameState.Running);
		GameSceneAnimationHandler.instance.PlayCountAnimation(2);
		GameSceneUIManager.instance.SetUiForResumeGame();
	}

}
