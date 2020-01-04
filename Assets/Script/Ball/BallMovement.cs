using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour, IColliderEnter
{
	[SerializeField] private Rigidbody2D _rb;

	private Ball _ball = new Ball();
	private bool _canBallMove;
	private Vector2 _initialVelocity ;
	private Vector2 _maxVelocity;
	private Renderer rendere;

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
		_initialVelocity = this._ball.initialVelocity;
		_maxVelocity   = this._ball.maximumVelocity;
		 rendere = this.gameObject.GetComponent<SpriteRenderer>();

		SetInitialVelocityBasedonDirection(GameEnums.Walls.left);
		SetInitialPositionBasedOnDirection(GameEnums.Walls.left);
		// StartMove(true);
		StopMove();
	}

	public void StartMove(bool isItFirstTime = false)
	{
		_canBallMove = true;
		_rb.isKinematic = !_canBallMove;
		if (isItFirstTime || _rb.velocity == Vector2.zero)
			_rb.velocity = _initialVelocity;
		else
			_rb.velocity = _rb.velocity;
	}

	public void StopMove()
	{
		_canBallMove = false;
		_rb.isKinematic = !_canBallMove;
	}

	void onGameStateChanged(GameEnums.GameState gameState)
	{
		Debug.Log("STtae Changed  : " + gameState);
		if (gameState == GameEnums.GameState.Running)
			StartMove();
		else
			StopMove();
	}

	public void onCollide(Collision2D colidedObj2D)
	{
		if (Mathf.Abs(_rb.velocity.x) <= _maxVelocity.x && Mathf.Abs(_rb.velocity.y) <= _maxVelocity.y)
		    _rb.velocity = _rb.velocity * (1.1f);
	}

	public void ResetPosition(GameEnums.Walls nextWall)
	{
		rendere.enabled = false;
		this.gameObject.transform.position = SetInitialPositionBasedOnDirection(nextWall);
		StartCoroutine(waitAndResetPosition(nextWall));
	}

	IEnumerator waitAndResetPosition(GameEnums.Walls nextWall)
	{
		yield return new WaitForSeconds(.5f);
		SetInitialVelocityBasedonDirection(nextWall);
		StartMove(true);
		rendere.enabled = true;
	}

	void SetInitialVelocityBasedonDirection(GameEnums.Walls nextWall)
	{
		if (_initialVelocity.x < 0)
			_initialVelocity = _initialVelocity * (-1);  //Made all velocity positive
		 //If wall is right direction is already positive , if next wall is left then made velocity negative

	   _initialVelocity = 	GenerateRandomVelocity(_initialVelocity);
		if (nextWall == GameEnums.Walls.left)
			_initialVelocity = _initialVelocity * (-1);
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
