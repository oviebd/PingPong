using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

	public BallMovement _ballMovement;
	public Rigidbody2D _rb;

	private Ball _ball = new Ball();
	IBallBehaviour ballBehaviour;


	void Start()
	{
		//_ballMovement = this.gameObject.GetComponent<BallMovement>();
		//_rb = this.gameObject.GetComponent<Rigidbody2D>();
		ballBehaviour = new BallType_1_Behaviour();
		ballBehaviour.SetUp(this);

		GameManager.gameStateChanged += onGameStateChanged;

	}
	void OnDestroy()
	{
		GameManager.gameStateChanged -= onGameStateChanged;
	}
	public void setBall(Ball ball)
	{
		this._ball = ball;

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
