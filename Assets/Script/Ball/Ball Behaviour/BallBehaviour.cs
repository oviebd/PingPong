using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour,IColliderEnter
{

	public BallMovement _ballMovement;
	public Rigidbody2D _rb;

	private Ball _ball = new Ball();
	IBallBehaviour ballBehaviour;


	void Start()
	{
		GameManager.gameStateChanged += onGameStateChanged;
	}
	void OnDestroy()
	{
		GameManager.gameStateChanged -= onGameStateChanged;
	}

    public void setBall(Ball ball)
	{
		this._ball = ball;
        ballBehaviour = ball.ballBehaviour;
        // ballBehaviour = new NormalBallBehaviour();
        ballBehaviour.SetUp(this);
        _ballMovement.setBall(ball);
	}
	public Rigidbody2D GetRb()
	{
		return _rb;
	}
	public BallMovement GetBallMovement()
	{
		return _ballMovement;
	}
	public Ball GetBall()
	{
		return _ball;
	}

	public void UpdateBall(Ball ball)
	{
		this._ball = ball;
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
