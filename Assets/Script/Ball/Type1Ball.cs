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
		ball.initialVelocity = new Vector2(6.0f, 6.0f); ;
	}

	public void SetMaxVelocity()
	{
		ball.maximumVelocity = new Vector2(10.0f, 10.0f);
	}
	public Ball getBall()
	{
		return ball;
	}
}
