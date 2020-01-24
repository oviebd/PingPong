using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type1Ball : IBallBuilder
{
	Ball ball = new Ball();
	public void SetBallType()
	{
		ball.ballType = GameEnums.ballType.type1;
	}

	public void SetColor(Color color)
	{
		ball.color = color;
	}
	public void SetInitialVelocity()
	{
		ball.initialVelocity = new Vector2(15.0f, 15.0f); 
	}

	public void SetMaxVelocity()
	{
		ball.maximumVelocity = new Vector2(25.0f, 25.0f);
	}
	public Ball getBall()
	{
		return ball;
	}
}
