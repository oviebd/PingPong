using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBallBehaviour : MonoBehaviour,IBallBehaviour, IColliderEnter
{
	private BallMovement _ballMovement;
	private Rigidbody2D  _rb;

	private void Start()
	{
		_ballMovement = this.gameObject.GetComponent<BallMovement>();
		_rb = this.gameObject.GetComponent<Rigidbody2D>();
	}

	public void OperationAfterCollision()
	{
		
	}

	public void onCollide(Collision2D colidedObj2D)
	{
	//	Debug.Log("Collided ball with " + colidedObj2D.gameObject.tag);
		if (colidedObj2D.gameObject.tag == GameEnums.Tag.paddle.ToString())
			UpdateSpeed();
	}

	void UpdateSpeed()
	{
		if (_ballMovement != null && _rb != null)
		{
			Vector2 maxVelocity = _ballMovement.GetBall().maximumVelocity;
		//	Debug.Log("SpeedUp ball " + maxVelocity);
			if (Mathf.Abs(_rb.velocity.x) <= maxVelocity.x && Mathf.Abs(_rb.velocity.y) <= maxVelocity.y)
				_rb.velocity = _rb.velocity * (1.01f);
		}
	}
}
