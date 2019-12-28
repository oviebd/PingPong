using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour,IMove {

    float paddleSpeed = 8.0f;
	private bool _canMovePaddle = true;
	private GameEnums.PaddleInput _paddleInputState;
	private GameEnums.PaddleInput _stuckPaddleInputState = GameEnums.PaddleInput.none;

	BallMovement _ballMovement;
	public bool isItAutoMoveable = false;


	void Update()
    {
		if (isItAutoMoveable)
		{
			AutomaticPaddleMoveMent();
			return;
		}
			
		if (Input.GetKey(KeyCode.UpArrow))
        {
			MoveUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
			MoveDown();
        }
    }

	public void MoveUp()
	{
		_paddleInputState = GameEnums.PaddleInput.inputUp;
		SetMovement(true);
	}

	public void MoveDown()
	{
		_paddleInputState = GameEnums.PaddleInput.inputDown;
		SetMovement(false);
	}

	public void SetMovement(bool isMoveUp)
	{
		if (CanMove() == false)
		{
			if (_stuckPaddleInputState == _paddleInputState)
				return;
			else
				SetMoveEnableDisable(true);
		}

		Vector3 position = this.transform.position;
		if (isMoveUp)
			position.y = position.y + (paddleSpeed * Time.deltaTime);
		else
			position.y = position.y - (paddleSpeed * Time.deltaTime); ;

		this.transform.position = position;
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

	

	void AutomaticPaddleMoveMent()
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

	}

	
}
