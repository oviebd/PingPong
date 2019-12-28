using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour, IColliderEnter
{
	private Ball _ball = new Ball();
	private bool _canBallMove;
	[SerializeField] private Rigidbody2D _rb;

	private Vector2 _initialVelocity ;
	private Vector2 _maxVelocity;
	private Vector3 _initialPosition;
	private Renderer rendere;
	public void setBall(Ball ball)
	{
		this._ball = ball;
		_initialVelocity = this._ball.initialVelocity;
		_maxVelocity   = this._ball.maximumVelocity;
		_initialPosition = this.gameObject.transform.position;
		 rendere = this.gameObject.GetComponent<SpriteRenderer>();
		//_rb.velocity = _initialVelocity;
		SetInitialVelocityBasedonDirection(GameEnums.Walls.left);
	   StartMove(true);
	}

	public void StartMove(bool isItFirstTime = false)
	{
		_canBallMove = true;
		_rb.isKinematic = !_canBallMove;
		//_rb.AddForce(_initialVelocity);
		if (isItFirstTime)
			_rb.velocity = _initialVelocity;
		else
			_rb.velocity = _rb.velocity;
	}

	public void StopMove()
	{
		_canBallMove = false;
		_rb.isKinematic = !_canBallMove;
	}

	void Start () {
		//StopMove();
	}
	

	public void onCollide(Collision2D colidedObj2D)
	{
		if (colidedObj2D.gameObject.GetComponent<Rigidbody2D>() )
		{
			/*Debug.Log("Prev Velocity ; " + _rb.velocity);
			float playerVelocity = colidedObj2D.gameObject.GetComponent<Rigidbody2D>().velocity.y;
			float newYVelocity = (playerVelocity / 3.0f) + (_rb.velocity.y / 2.0f);
			_rb.velocity = new Vector2(_rb.velocity.x, newYVelocity);
			Debug.Log("New Velocity ; " + _rb.velocity);*/
		}

		if (Mathf.Abs(_rb.velocity.x) <= _maxVelocity.x && Mathf.Abs(_rb.velocity.y) <= _maxVelocity.y)
		    _rb.velocity = _rb.velocity * (1.1f);
	}

	public void ResetPosition(GameEnums.Walls nextWall)
	{
		rendere.enabled = false;
		this.gameObject.transform.position = _initialPosition;
		StartCoroutine(waitAndResetPosition(nextWall));
	}

	IEnumerator waitAndResetPosition(GameEnums.Walls nextWall)
	{
		yield return new WaitForSeconds(.5f);
		rendere.enabled = true;
		SetInitialVelocityBasedonDirection(nextWall);
		StartMove(true);
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
	
	Vector2 GenerateRandomVelocity(Vector2 velocity)
	{
		float x = Random.Range(_initialVelocity.x / 1.5f, _maxVelocity.x / 2);
		float y = Random.Range(_initialVelocity.y / 1.5f, _maxVelocity.y / 2);
		return new Vector2(x, y);
	}
}
