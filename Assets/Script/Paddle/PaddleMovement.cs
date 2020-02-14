using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour,IMove {

    float paddleSpeed = 10.0f;
	private bool _canMovePaddle = true;
	private GameEnums.PaddleInput _paddleInputState;
	private GameEnums.PaddleInput _stuckPaddleInputState = GameEnums.PaddleInput.none;
	private Vector2 _movement = Vector2.zero;

	BallMovement _ballMovement;
	public bool isItAutoMoveable = false;

	private void Start()
	{
		InputManager.onRightButtonPressed += MoveRight;
		InputManager.onLeftButtonPressed += MoveLeft;
	}

	private void FixedUpdate()
	{
		if(GameManager.instance.GetCurrentGameState() == GameEnums.GameState.Running)
		{
			_movement.x = transform.position.x +  ( _movement.x * paddleSpeed * Time.deltaTime);
			_movement.y = transform.position.y;
			this.transform.position =  _movement;
		}
	}

	public void MoveRight()
	{
		_movement = new Vector2(-1, 0);
	
		//_paddleInputState = GameEnums.PaddleInput.inputRight;
		//SetMovement(true);
	}


	public void MoveLeft()
	{
		_movement = new Vector2(-1, 0);
		//_paddleInputState = GameEnums.PaddleInput.inputLeft;
		//SetMovement(false);
	}

	public void SetMovement(bool isMoveRight)
	{
		/*if (CanMove() == false)
		{
			if (_stuckPaddleInputState == _paddleInputState)
				return;
			else
				SetMoveEnableDisable(true);
		}

		Vector3 position = this.transform.position;
		if (isMoveRight)
			position.x = position.x + (paddleSpeed * Time.deltaTime);
		else
			position.x = position.x - (paddleSpeed * Time.deltaTime); ;

		this.transform.position = position;*/
	}

	public bool CanMove()
	{
		return _canMovePaddle;
	}

	public void SetMoveEnableDisable(bool canMove)
	{
		if(canMove== false)
			_stuckPaddleInputState = _paddleInputState;
		else
			_stuckPaddleInputState = GameEnums.PaddleInput.none;

		_canMovePaddle = canMove;
	}

	/*void AutomaticPaddleMoveMent()
	{
		if(_ballMovement == null)
		{
			_ballMovement  = FindObjectOfType<BallMovement>();
		}
		if (_ballMovement == null)
			return;

		MovePaddleAI(_ballMovement);
	}

	void MovePaddleAI(BallMovement ballMovement)
	{
		Vector2 ballPosition = ballMovement.gameObject.transform.position;
		Vector2 paddlePosition = this.gameObject.transform.position;

		float d = Vector2.Distance(ballPosition,paddlePosition);
		//Debug.Log("Distance : " + d);

		if( d<= 7.0f)
		{
			if(paddlePosition.y < ballPosition.y )
				MoveUp();
			
			if (paddlePosition.y > ballPosition.y)
				MoveDown();
		}

	}*/

	
}
