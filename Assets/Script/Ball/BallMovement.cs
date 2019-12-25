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
		_rb.AddForce(_initialVelocity);
		//_rb.velocity = _rb.velocity;
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
}
