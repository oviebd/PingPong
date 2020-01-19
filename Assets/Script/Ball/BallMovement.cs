﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour, IColliderEnter
{
	[SerializeField] private Rigidbody2D _rb;
    [SerializeField] private TrailRenderer _trailRenderer;

    private Ball _ball = new Ball();
	private Vector2 _initialVelocity;
	private Vector2 _maxVelocity;
	private Vector2 _previousVelocity;
	private Renderer _rendere;

	void OnDestroy()
	{
		GameManager.gameStateChanged -= onGameStateChanged;
	}

	public void setBall(Ball ball)
	{
		this._ball = ball;
		GameManager.gameStateChanged += onGameStateChanged;

		_rendere = this.gameObject.GetComponent<SpriteRenderer>();
		SetInitialVelocityBasedonDirection(GameEnums.Walls.left);
		ResetPosition(GameEnums.Walls.left);
	}

	private void ResetBall()
	{
		StopBallMovement();
		_initialVelocity = this._ball.initialVelocity;
		_previousVelocity = _initialVelocity;
		_maxVelocity = this._ball.maximumVelocity;
	}

	void SetBallVisibleAnbMoveAble(bool canMove)
	{
		_rendere.enabled = canMove;
		_rb.isKinematic = !canMove; // if ball can move than set kinematic false
        _trailRenderer.enabled = canMove;
    }

	private void StartBallMovement()
	{
		SetBallVisibleAnbMoveAble(true);
	    _rb.velocity = _previousVelocity;
	}

	private void StopBallMovement()
	{
		_previousVelocity = _rb.velocity;
		_rb.velocity = Vector2.zero;
		SetBallVisibleAnbMoveAble(false);
		
	}
	void onGameStateChanged(GameEnums.GameState gameState)
	{
		switch (gameState)
		{
			case GameEnums.GameState.Running:
				StartBallMovement();
				break;
			case GameEnums.GameState.Over:
				StopBallMovement();
				Destroy(gameObject);
				break;
			default:
				StopBallMovement();
				break;
		}
	}

	public void onCollide(Collision2D colidedObj2D)
	{
		if (Mathf.Abs(_rb.velocity.x) <= _maxVelocity.x && Mathf.Abs(_rb.velocity.y) <= _maxVelocity.y)
		    _rb.velocity = _rb.velocity * (1.01f);
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
		_previousVelocity = SetInitialVelocityBasedonDirection(nextWall);
	}

	Vector2 SetInitialVelocityBasedonDirection(GameEnums.Walls nextWall)
	{
		if (_initialVelocity.x < 0)
			_initialVelocity = _initialVelocity * (-1);  //Made all velocity positive
		 //If wall is right direction is already positive , if next wall is left then made velocity negative

	   _initialVelocity = 	BallPositionHandler.GenerateRandomVelocity(_initialVelocity,this._ball);
		if (nextWall == GameEnums.Walls.left)
			_initialVelocity = _initialVelocity * (-1);
		return _initialVelocity;
	}

}
