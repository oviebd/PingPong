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

	public void setBall(Ball ball)
	{
		this._ball = ball;
		_initialVelocity = this._ball.initialVelocity;
		_maxVelocity   = this._ball.maximumVelocity;
		_rb.velocity = _initialVelocity;
	//	StartMove();
	}

	public void StartMove()
	{
		_canBallMove = true;
		_rb.isKinematic = !_canBallMove;
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
		if (Mathf.Abs(_rb.velocity.x) <= _maxVelocity.x && Mathf.Abs(_rb.velocity.y) <= _maxVelocity.y)
			_rb.velocity = _rb.velocity * (1.1f);
	}
}
