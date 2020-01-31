using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallPositionHandler  {

    public static Vector2 SetInitialPositionBasedOnDirection(GameEnums.Walls nextWall)
	{
		float threshHoldXPosition = 2; // for keeping distance from peddle
		float y = Random.Range(BoundaryController.instance.GetBottomWallPosition().y, BoundaryController.instance.GetTopWallPosition().y);

        Vector2 worldLeftrightCornerPosition = BoundaryController.instance.GetWidthInWorldSpace();

        float x = worldLeftrightCornerPosition.x ;
       
        if (nextWall == GameEnums.Walls.left)
            x = x - threshHoldXPosition;
        if (nextWall == GameEnums.Walls.right)
            x = ( x * (-1) ) + threshHoldXPosition;

        Vector2 newResetPosition = new Vector2(x, y);
		return newResetPosition;
	}

	public  static Vector2 GenerateRandomPositiveVelocity(Vector2 minimumVelocity, Vector2 maximumVelocity)
	{
        Vector2 randomVelocity = Vector2.zero;
		float x = Random.Range(minimumVelocity.x / 1.5f, maximumVelocity.x / 2);
		float y = Random.Range(minimumVelocity.y / 1.5f, minimumVelocity.y / 2);

        randomVelocity = new Vector2(x, y);

        if (randomVelocity.x < 0)
            randomVelocity = randomVelocity * (-1);
        return randomVelocity;
	}

   public  static Vector2 SetInitialVelocityBasedonDirection(GameEnums.Walls nextWall,Vector2 initialVelocity)
	{
        if (nextWall == GameEnums.Walls.left)
			initialVelocity = initialVelocity * (-1);


        return initialVelocity;
	}

}
