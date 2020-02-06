using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rb;
    //[SerializeField] private TrailRenderer _trailRenderer;
	private Renderer _rendere;

	//private Ball _ball = new Ball();
	private Vector2 _initialVelocity;
	private Vector2 _maxVelocity;
	private Vector2 _previousVelocity;

	BallBehaviour _ballBehaviour;

	void Start()
	{
		_ballBehaviour = this.gameObject.GetComponent<BallBehaviour>();
	}
	public void setBall(Ball ball)
	{
		_rendere = this.gameObject.GetComponent<SpriteRenderer>();
		//_initialVelocity = BallPositionHandler.GenerateRandomPositiveVelocity(getBall().initialVelocity, getBall().maximumVelocity);
		_initialVelocity = getBall().initialVelocity;
		BallPositionHandler.SetInitialVelocityBasedonDirection(GameEnums.Walls.left,_initialVelocity);

        ResetPosition(GameEnums.Walls.left);
	}

	Ball getBall()
	{
		if (_ballBehaviour == null)
		{
			_ballBehaviour = this.gameObject.GetComponent<BallBehaviour>();
			return _ballBehaviour.GetBall();
		}		
		else
			return _ballBehaviour.GetBall();
	}

    public Vector2 GetInitialVelocity()
    {
        return _initialVelocity;
    }

	private void ResetBall()
	{
		StopBallMovement();
		_initialVelocity = getBall().initialVelocity;
		_previousVelocity = _initialVelocity;
		_maxVelocity = getBall().maximumVelocity;
	}

	void SetBallVisibleAnbMoveAble(bool canMove)
	{
		_rendere.enabled = canMove;
		_rb.isKinematic = !canMove; // if ball can move than set kinematic false
       // _trailRenderer.enabled = canMove;
    }

	public void StartBallMovement()
	{
		SetBallVisibleAnbMoveAble(true);
	    _rb.velocity = _previousVelocity;
	}

	public void StopBallMovement()
	{
		_previousVelocity = _rb.velocity;
		_rb.velocity = Vector2.zero;
		SetBallVisibleAnbMoveAble(false);
		
	}

	public void ResetPosition(GameEnums.Walls nextWall)
	{
		ResetBall();
		this.gameObject.transform.position =  BallPositionHandler.SetInitialPositionBasedOnDirection(nextWall);
		StartCoroutine(waitAndResetPosition(nextWall));
	}

	IEnumerator waitAndResetPosition(GameEnums.Walls nextWall)
	{
		yield return new WaitForSeconds(.5f);

        _initialVelocity = BallPositionHandler.GenerateRandomPositiveVelocity(getBall().initialVelocity,getBall().maximumVelocity);
        _previousVelocity = BallPositionHandler.SetInitialVelocityBasedonDirection(nextWall,_initialVelocity);
	}

	

}
