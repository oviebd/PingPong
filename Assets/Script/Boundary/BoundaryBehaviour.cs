using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBehaviour : MonoBehaviour, IColliderEnter
{
	[SerializeField] private GameEnums.Walls _wallName;
	private Collider2D _collider;

	public delegate void OnBallCollidedWithLeftRightWall(GameEnums.PlayerEnum scoringPlayer,GameEnums.Walls nextWall); //In which direction ball will go next
	public static event OnBallCollidedWithLeftRightWall updateScoreManagerData;

	void Start()
	{
		_collider = this.gameObject.GetComponent<Collider2D>();
	}
	public void onCollide(Collision2D colidedObj2D)
	{
		string collidedObjTag = colidedObj2D.gameObject.tag;
	//	Debug.Log("tag    " + collidedObjTag);
		if (collidedObjTag == GameEnums.Tag.ball.ToString())
		{
			BallHitOnWalls();
		}
	}

	void BallHitOnWalls()
	{
		switch (_wallName)
		{
			case GameEnums.Walls.left:
				updateScoreManagerData(GameEnums.PlayerEnum.Player1_Right, GameEnums.Walls.right);
				break;

			case GameEnums.Walls.right:
				updateScoreManagerData(GameEnums.PlayerEnum.Player2_Left, GameEnums.Walls.left);
				break;
		}
	}

	IEnumerator MadeWallNotCollidableForSometime()
	{
		_collider.enabled = false;
		yield return new WaitForSeconds(0.1f);
		_collider.enabled = true;
	}

    public BoxCollider2D GetCollider()
    {
        return (BoxCollider2D)_collider;
    }

}
