using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepapreGameStage : MonoBehaviour
{
    public static PrepapreGameStage instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PrepareNewGame()
    {
        ScoreManager.instance.ResetScore();
        ObstacleController.instance.PrepareObstacleControllerForNewGame();
        BallController.instance.PrepareBallControllerForNewGame();
        GameSceneUIManager.instance.SetUiForANewGame();
        StartCoroutine(SetGameStateRunning());
    }

    public void PrepareResumeGame()
    {
        GameSceneUIManager.instance.SetUiForResumeGame();
        StartCoroutine(SetGameStateRunning());
    }

	public void PrepareReviveGame()
	{
		BallController.instance.InstantiateBall(GameEnums.ballType.NormalBall_Type1);
		StartCoroutine(SetGameStateRunning());
	}
	public void PrepareLevelUp()
    {
        ScoreManager.instance.ResetScore();
        ObstacleController.instance.PrepareObstacleControllerForNewGame();
        BallController.instance.PrepareBallControllerForNewGame();
        GameSceneUIManager.instance.SetUiForANewGame();
        StartCoroutine(SetGameStateRunning());
    }

     IEnumerator  SetGameStateRunning()
    {
        yield return new WaitForSeconds(1.0f);
        GameManager.instance.SetCurrentGameState(GameEnums.GameState.Running);
    }

}
