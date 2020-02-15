using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PaddleMovement))]
[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
	public GameEnums.PlayerEnum player;
}
