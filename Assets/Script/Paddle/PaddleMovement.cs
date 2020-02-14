using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    float paddleSpeed = 10.0f;

	private void Start()
	{
		InputManager.onRightButtonPressed += MoveRight;
		InputManager.onLeftButtonPressed += MoveLeft;
	}
    private void OnDestroy()
    {
		InputManager.onRightButtonPressed -= MoveRight;
		InputManager.onLeftButtonPressed -= MoveLeft;
	}


    private void MoveRight()
	{
		SetMovement(true);
	}


	private void MoveLeft()
	{
		SetMovement(false);
	}

	private void SetMovement(bool isMoveRight)
	{
		if (GameManager.instance.GetCurrentGameState() != GameEnums.GameState.Running)
			return;

		Vector3 position = this.transform.position;
		if (isMoveRight)
			position.x = position.x + (paddleSpeed * Time.deltaTime);
		else
			position.x = position.x - (paddleSpeed * Time.deltaTime); ;

		float paddleOffset = this.transform.localScale.x /2.0f;

        if( position.x < ( BoundaryController.instance.GetRightWallPosition().x - paddleOffset ) &&
			position.x > ( BoundaryController.instance.GetLeftWallPosition().x + paddleOffset))
			this.transform.position = position;
	}
	
}
