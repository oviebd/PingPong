using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour,IMove {

    float paddleSpeed = 5.0f;
	private bool _canMovePaddle = true;
	private GameEnums.PaddleInput _paddleInputState;
	private GameEnums.PaddleInput _stuckPaddleInputState = GameEnums.PaddleInput.none;

	void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
			_paddleInputState = GameEnums.PaddleInput.inputUp;
			SetMovement(true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
			_paddleInputState = GameEnums.PaddleInput.inputDown;
			SetMovement(false);
        }
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
}
