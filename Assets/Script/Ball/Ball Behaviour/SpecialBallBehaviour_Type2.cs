using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBallBehaviour_Type2 :  IBallBehaviour
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

	public void OperationAfterCollision(Collision2D colidedObj2D)
	{
        //GoPreviousDirection();
        if (colidedObj2D.gameObject.tag == GameEnums.Tag.obstacle.ToString())
            GoPreviousDirection();
        if (colidedObj2D.gameObject.tag == GameEnums.Tag.paddle.ToString() ||
                           colidedObj2D.gameObject.tag == GameEnums.Tag.wall.ToString())
            SetInitialVelocity();
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
            _rb.velocity = Vector2.zero;
			_rb.velocity = initialVelocity;
            //_rb.AddForce (initialVelocity);
        }
	}

	
}
