using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour, IColliderEnter
{
	[SerializeField] private GameEnums.Walls _wallName;

	public delegate void OnBallCollisionWithLeftRightWall(GameEnums.PlayerEnum winnerPlayer);
	public static event OnBallCollisionWithLeftRightWall BallCollisionWithLeftRightWall;

	public void onCollide(Collision2D colidedObj2D)
	{
		string collidedObjTag = colidedObj2D.gameObject.tag;
	//	Debug.Log("tag    " + collidedObjTag);
		if (collidedObjTag == GameEnums.Tag.ball.ToString())
		{
			ballHitOnWalls();
		}
	}

	void ballHitOnWalls()
	{
		switch (_wallName)
		{
			case GameEnums.Walls.left:
				BallCollisionWithLeftRightWall(GameEnums.PlayerEnum.Player1_Right);
				break;

			case GameEnums.Walls.right:
				BallCollisionWithLeftRightWall(GameEnums.PlayerEnum.Player2_Left);
				break;
		}
	}

}
