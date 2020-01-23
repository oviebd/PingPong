using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallType_1_Behaviour :  IBallBehaviour, IColliderEnter
{
	private Vector2 initialVelocity = Vector2.zero;
	private Rigidbody2D _rb;

	BallBehaviour _ballBehaviour;
	public void SetUp(BallBehaviour behaviour)
	{
		this._ballBehaviour = behaviour;
		_rb = _ballBehaviour.GetRb();
		initialVelocity = behaviour.GetBallMovement().GetInitialVelocity();
	
	}

	public void onCollide(Collision2D colidedObj2D)
	{
		if (colidedObj2D.gameObject.tag == GameEnums.Tag.obstacle.ToString())
			OperationAfterCollision();
		if (colidedObj2D.gameObject.tag == GameEnums.Tag.paddle.ToString())
			SetInitialVelocity();
	}

	public void OperationAfterCollision()
	{
		GoPreviousDirection();
	}

	void SetInitialVelocity()
	{
		if (_rb != null)
		{
			initialVelocity = _rb.velocity;
		}
		//Debug.Log("init vel : " + initialVelocity);
	}
	void GoPreviousDirection()
	{
		if ( _rb != null )
		{
			_rb.velocity = initialVelocity;
		}
	}

	
}
