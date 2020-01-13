using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour, IColliderEnter
{
	[SerializeField] private Rigidbody2D _rb;
    [SerializeField] private TrailRenderer _trailRenderer;

    private Ball _ball = new Ball();
	private Vector2 _initialVelocity;
	private Vector2 _maxVelocity;
	private Vector2 _previousVelocity;
	private Renderer _rendere;

	private CountTextAnimation _countTextAnimation;

	void OnDestroy()
	{
		GameManager.gameStateChanged -= onGameStateChanged;
	}

	public void setBall(Ball ball)
	{
		this._ball = ball;
		GameManager.gameStateChanged += onGameStateChanged;

		_rendere = this.gameObject.GetComponent<SpriteRenderer>();
		SetInitialVelocityBasedonDirection(GameEnums.Walls.left);
		SetInitialPositionBasedOnDirection(GameEnums.Walls.left);
		ResetBall();
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


	private void StartBallMovement()
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

	public void onCollide(Collision2D colidedObj2D)
	{
		if (Mathf.Abs(_rb.velocity.x) <= _maxVelocity.x && Mathf.Abs(_rb.velocity.y) <= _maxVelocity.y)
		    _rb.velocity = _rb.velocity * (1.1f);
	}

	public void ResetPosition(GameEnums.Walls nextWall)
	{
		ResetBall();
		this.gameObject.transform.position = SetInitialPositionBasedOnDirection(nextWall);
		StartCoroutine(waitAndResetPosition(nextWall));
	}

	IEnumerator waitAndResetPosition(GameEnums.Walls nextWall)
	{
		yield return new WaitForSeconds(.5f);
		_previousVelocity = SetInitialVelocityBasedonDirection(nextWall);
	}

	Vector2 SetInitialVelocityBasedonDirection(GameEnums.Walls nextWall)
	{
		if (_initialVelocity.x < 0)
			_initialVelocity = _initialVelocity * (-1);  //Made all velocity positive
		 //If wall is right direction is already positive , if next wall is left then made velocity negative

	   _initialVelocity = 	GenerateRandomVelocity(_initialVelocity);
		if (nextWall == GameEnums.Walls.left)
			_initialVelocity = _initialVelocity * (-1);
		return _initialVelocity;
	}
	Vector2 SetInitialPositionBasedOnDirection(GameEnums.Walls nextWall)
	{
		float threshHoldXPosition = 3; // for keeping distance from peddle
		float y = Random.Range(BoundaryController.instance.GetBottomWallPosition().y, BoundaryController.instance.GetTopWallPosition().y);
		float x = 1.0f;

		if (nextWall == GameEnums.Walls.left)
			x = BoundaryController.instance.GetRightWallPosition().x ;
		if (nextWall == GameEnums.Walls.right)
			x = BoundaryController.instance.GetLeftWallPosition().x ;

		if (x < 0)
			x = x + threshHoldXPosition;
		else
			x = x - threshHoldXPosition;

		Vector2 newResetPosition = new Vector2(x, y);
		return newResetPosition;
	}
	Vector2 GenerateRandomVelocity(Vector2 velocity)
	{
		float x = Random.Range(_initialVelocity.x / 1.5f, _maxVelocity.x / 2);
		float y = Random.Range(_initialVelocity.y / 1.5f, _maxVelocity.y / 2);
		return new Vector2(x, y);
	}
}
