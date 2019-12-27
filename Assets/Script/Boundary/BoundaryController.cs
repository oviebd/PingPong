using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour, IColliderEnter
{
	[SerializeField] private GameEnums.Walls _wallName;

	public delegate void onPaddleCollidedWithBall(GameEnums.PlayerEnum player);
	public static event onPaddleCollidedWithBall scoreUpdate;

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
				scoreUpdate(GameEnums.PlayerEnum.Player1_Right);
				break;

			case GameEnums.Walls.right:
				scoreUpdate(GameEnums.PlayerEnum.Player2_Left);
				break;
		}
	}

}
