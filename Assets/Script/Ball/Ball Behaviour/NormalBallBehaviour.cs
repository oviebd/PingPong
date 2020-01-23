using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBallBehaviour : IBallBehaviour, IColliderEnter
{
	public BallMovement _ballMovement;
	public Rigidbody2D _rb;
	BallBehaviour _behaviour;
	public void SetUp(BallBehaviour behaviour)
	{
		this._behaviour = behaviour;
		_rb = behaviour.GetRb();
		_ballMovement = behaviour.GetBallMovement();
	}

	public void OperationAfterCollision()
	{
        UpdateSpeed();
       // SetInitialVelocity();
    }

	public void onCollide(Collision2D colidedObj2D)
	{
		//Debug.Log("Collided ball with " + colidedObj2D.gameObject.tag);
		if (colidedObj2D.gameObject.tag == GameEnums.Tag.paddle.ToString())
            OperationAfterCollision();
    /*    if (colidedObj2D.gameObject.tag == GameEnums.Tag.obstacle.ToString())
        {
            GoPreviousDirection();
        }*/


    }

	void UpdateSpeed()
	{
		if (_ballMovement != null && _rb != null)
		{
			Vector2 maxVelocity = _behaviour.GetBall().maximumVelocity;
		//	Debug.Log("SpeedUp ball " + maxVelocity);
			if (Mathf.Abs(_rb.velocity.x) <= maxVelocity.x && Mathf.Abs(_rb.velocity.y) <= maxVelocity.y)
				_rb.velocity = _rb.velocity * (1.01f);
		}
	}
}
