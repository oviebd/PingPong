using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallPositionHandler  {
	public static Vector2 SetInitialPositionBasedOnDirection(GameEnums.Walls nextWall)
	{
		float threshHoldXPosition = 3; // for keeping distance from peddle
		float y = Random.Range(BoundaryController.instance.GetBottomWallPosition().y, BoundaryController.instance.GetTopWallPosition().y);
		float x = 1.0f;

		if (nextWall == GameEnums.Walls.left)
			x = BoundaryController.instance.GetRightWallPosition().x;
		if (nextWall == GameEnums.Walls.right)
			x = BoundaryController.instance.GetLeftWallPosition().x;

		if (x < 0)
			x = x + threshHoldXPosition;
		else
			x = x - threshHoldXPosition;

		Vector2 newResetPosition = new Vector2(x, y);
		return newResetPosition;
	}

	public  static Vector2 GenerateRandomVelocity(Vector2 velocity, Ball ball)
	{
		float x = Random.Range(ball.initialVelocity.x / 1.5f, ball.maximumVelocity.x / 2);
		float y = Random.Range(ball.initialVelocity.y / 1.5f, ball.maximumVelocity.y / 2);
		return new Vector2(x, y);
	}

}
