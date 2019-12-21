using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour,IMove {

    float paddleSpeed = 5.0f;
	private bool _canMovePaddle = true;

	void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
			Movement(true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
			Movement(false);
        }
    }


	public void Movement(bool isMoveUp)
	{
		if (CanMove() == false)
			return;

		Vector3 position = this.transform.position;

		if (isMoveUp)
			position.y = position.y + (paddleSpeed * Time.deltaTime);
		else
			position.y = position.y - (paddleSpeed * Time.deltaTime); ;

		this.transform.position = position;
	}

	public void StopMovement()
	{
		_canMovePaddle = false;
	}

	public void StartMovement()
	{
		_canMovePaddle = true;
	}

	public bool CanMove()
	{
		return _canMovePaddle;
	}
}
