using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleMovement))]
[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour, Collideable
{
	public delegate void onPaddleCollidedWithBall();
	public static  event onPaddleCollidedWithBall scoreUpdate;

	public void onCollide(Collision2D collision2D)
	{
		//Debug.Log("Name : " + collision2D.gameObject.name);
		scoreUpdate();
	}
}
