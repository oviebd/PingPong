using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : BallBaseClass,IColliderEnter
{
	//private Ball _ball = new Ball();
	IBallBehaviour ballBehaviour;

    private void Awake()
    {
		//GameManager.gameStateChanged += onGameStateChanged;
	}

    void Start()
	{
		GameManager.gameStateChanged += onGameStateChanged;
	}

	void OnDestroy()
	{
		GameManager.gameStateChanged -= onGameStateChanged;
	}

    public void SetUp()
	{
        InitializeBall();
    
        ballBehaviour = this.gameObject.GetComponent<IBallBehaviour>();
        _ballMovement.setBall(GetBall());
        ballBehaviour.SetUp(this);
	}
	
    public void onCollide(Collision2D colidedObj2D)
    {
        ballBehaviour.OperationAfterCollision(colidedObj2D);
    }

    void onGameStateChanged(GameEnums.GameState gameState)
	{
		switch (gameState)
		{
			case GameEnums.GameState.Running:
				_ballMovement.StartBallMovement();
				break;
			case GameEnums.GameState.Over:
				_ballMovement.StopBallMovement();
				Destroy(gameObject);
				break;
			default:
				_ballMovement.StopBallMovement();
				break;
		}
	}
    
}
