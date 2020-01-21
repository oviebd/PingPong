using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rb;
    [SerializeField] private TrailRenderer _trailRenderer;

    private Ball _ball = new Ball();
	private Vector2 _initialVelocity;
	private Vector2 _maxVelocity;
	private Vector2 _previousVelocity;
	private Renderer _rendere;

	void OnDestroy()
	{
		GameManager.gameStateChanged -= onGameStateChanged;
	}


	public void setBall(Ball ball)
	{
		this._ball = ball;
		GameManager.gameStateChanged += onGameStateChanged;

		_rendere = this.gameObject.GetComponent<SpriteRenderer>();

        _initialVelocity = BallPositionHandler.GenerateRandomPositiveVelocity(_ball.initialVelocity, _ball.maximumVelocity);
        BallPositionHandler.SetInitialVelocityBasedonDirection(GameEnums.Walls.left,_initialVelocity);

        ResetPosition(GameEnums.Walls.left);
	}

    public Ball GetBall()
    {
        return _ball;
    }
    public void UpdateBall(Ball ball)
    {
        this._ball  = ball;
    }

	private void ResetBall()
	{
		StopBallMovement();
		_initialVelocity = this._ball.initialVelocity;
		_previousVelocity = _initialVelocity;
		_maxVelocity = this._ball.maximumVelocity;
	}

	void SetBallVisibleAnbMoveAble(bool canMove)
	{
		_rendere.enabled = canMove;
		_rb.isKinematic = !canMove; // if ball can move than set kinematic false
        _trailRenderer.enabled = canMove;
    }

	public void StartBallMovement()
	{
		SetBallVisibleAnbMoveAble(true);
	    _rb.velocity = _previousVelocity;
	}

	private void StopBallMovement()
	{
		_previousVelocity = _rb.velocity;
		_rb.velocity = Vector2.zero;
		SetBallVisibleAnbMoveAble(false);
		
	}
	void onGameStateChanged(GameEnums.GameState gameState)
	{
		switch (gameState)
		{
			case GameEnums.GameState.Running:
				StartBallMovement();
				break;
			case GameEnums.GameState.Over:
				StopBallMovement();
				Destroy(gameObject);
				break;
			default:
				StopBallMovement();
				break;
		}
	}

	public void ResetPosition(GameEnums.Walls nextWall)
	{
		ResetBall();
		this.gameObject.transform.position =  BallPositionHandler.SetInitialPositionBasedOnDirection(nextWall);
		StartCoroutine(waitAndResetPosition(nextWall));
	}

	IEnumerator waitAndResetPosition(GameEnums.Walls nextWall)
	{
		yield return new WaitForSeconds(.5f);

        _initialVelocity = BallPositionHandler.GenerateRandomPositiveVelocity(_ball.initialVelocity,_ball.maximumVelocity);
        _previousVelocity = BallPositionHandler.SetInitialVelocityBasedonDirection(nextWall,_initialVelocity);
	}

	

}
