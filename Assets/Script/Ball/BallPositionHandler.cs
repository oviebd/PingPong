using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallPositionHandler  {

    /* public static Vector2 SetInitialPositionBasedOnDirection(GameEnums.Walls nextWall)
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
     }*/

    public static Vector2 SetInitialPositionBasedOnDirection(GameEnums.Walls nextWall)
    {
        float threshHoldYPosition = 4; // for keeping distance from peddle
        float x = Random.Range(BoundaryController.instance.GetRightWallPosition().x, BoundaryController.instance.GetLeftWallPosition().x);

        Vector2 worldTopBottomPosition = BoundaryController.instance.GetHeightInWorldPosition();

        float y = worldTopBottomPosition.y;

        nextWall = GameEnums.Walls.bottom;

        if (nextWall == GameEnums.Walls.top)
            y = y - threshHoldYPosition;
        if (nextWall == GameEnums.Walls.bottom)
            y = (y * (-1)) + threshHoldYPosition;

        Vector2 newResetPosition = new Vector2(x, y);
        return newResetPosition;
    }

   public  static Vector2 SetInitialVelocityBasedonDirection(GameEnums.Walls nextWall,Vector2 initialVelocity)
	{
        if (nextWall == GameEnums.Walls.left)
			initialVelocity = initialVelocity * (-1);


        return initialVelocity;
	}

}
