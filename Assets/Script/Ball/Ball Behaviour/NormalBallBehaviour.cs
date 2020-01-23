using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBallBehaviour : MonoBehaviour,IBallBehaviour, IColliderEnter
{
	private BallMovement _ballMovement;
	private Rigidbody2D  _rb;
    private Vector2 initialVelocity = Vector2.zero;

    private void Start()
	{
		_ballMovement = this.gameObject.GetComponent<BallMovement>();
		_rb = this.gameObject.GetComponent<Rigidbody2D>();

        initialVelocity = _ballMovement.GetInitialVelocity();
        
       // SetInitialVelocity();
       // Invoke("SetInitialVelocity", 0.5f);
       // Debug.Log("init vel : " + initialVelocity);

    }

	public void OperationAfterCollision()
	{
        UpdateSpeed();
        SetInitialVelocity();
    }

    void SetInitialVelocity()
    {
        initialVelocity = _rb.velocity;
        Debug.Log("init vel : " + initialVelocity);
    }

	public void onCollide(Collision2D colidedObj2D)
	{
		//Debug.Log("Collided ball with " + colidedObj2D.gameObject.tag);
		if (colidedObj2D.gameObject.tag == GameEnums.Tag.paddle.ToString())
            OperationAfterCollision();
        if (colidedObj2D.gameObject.tag == GameEnums.Tag.obstacle.ToString())
        {
            GoPreviousDirection();
          // Invoke("GoPreviousDirection",.01f);
        }


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
    void GoPreviousDirection()
    {
        //Vector2 velocity = _rb.velocity;
       // Debug.Log("prev vel : " + velocity);
       // velocity = velocity * (-1);
        //Debug.Log("after vel : " + velocity + " Initial vel : " + initialVelocity);
        _rb.velocity = initialVelocity;
    }
}
