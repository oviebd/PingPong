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
	}

	void OnDestroy()
	{
		WinningConditionHandler.notifyGameManagerForBallCollisionOnLeftRightWall -= NotifyGameManagerForBallCollisionOnLeftRightWall;
	}

	public GameEnums.GameState GetCurrentGameState()
	{
		return _gameCurrentState;
	}
	public void SetCurrentGameState(GameEnums.GameState gameState)
	{
		_gameCurrentState = gameState;
		gameStateChanged(gameState);
	}

	void	NotifyGameManagerForBallCollisionOnLeftRightWall(bool isWinning, GameEnums.PlayerEnum winnerPlayer, GameEnums.Walls nextWallDirection)
	{
		// Debug.Log("Next Wall " + nextWallDirection);
		if (isWinning)
			playerWin(winnerPlayer);
		else
			BallController.instance.ResetBall(nextWallDirection);
	}

	void playerWin(GameEnums.PlayerEnum winnerPlayer)
	{
		_gameCurrentState = GameEnums.GameState.Over;
	}

	public void StartANewGame()
	{
		ScoreManager.instance.ResetScore();
		BallController.instance.ResetBall(GameEnums.Walls.left);
		GameManager.instance.SetCurrentGameState(GameEnums.GameState.Running);
		GameSceneUIManager.instance.SetUiForANewGame();
	}
	public void PauseGame()
	{
		GameManager.instance.SetCurrentGameState(GameEnums.GameState.Pause);
		GameSceneUIManager.instance.SetUiForPauseGame();
	}
	public void ResumeGame()
	{
		GameManager.instance.SetCurrentGameState(GameEnums.GameState.Running);
		GameSceneUIManager.instance.SetUiForResumeGame();
	}

}
