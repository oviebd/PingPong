using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleMovement))]
[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour, IColliderEnter
{
	public delegate void onPaddleCollidedWithBall(GameEnums.PlayerEnum player);
	public static  event onPaddleCollidedWithBall scoreUpdate;

	public GameEnums.PlayerEnum player;

	public void onCollide(Collision2D collision2D)
	{
		string collidedObjTag = collision2D.gameObject.tag;
	//	Debug.Log("collider tag'; " + collidedObjTag + "  ball tag  " + GameEnums.Tag.ball.ToString());		
	}

	void SetcollisionOperation(string collidedObjTag)
	{
		if (collidedObjTag == GameEnums.Tag.ball.ToString())
		{
			scoreUpdate(player);
		}
		else if (collidedObjTag == GameEnums.Tag.wall.ToString())
		{

		}
	}

	void SetPlayerMovementOnOff()
	{

	}

	
}
