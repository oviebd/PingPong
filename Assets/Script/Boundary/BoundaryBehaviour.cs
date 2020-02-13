using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBehaviour : MonoBehaviour, IColliderEnter
{
	[SerializeField] private GameEnums.Walls _wallName;
	private Collider2D _collider;

	public delegate void OnBallCollidedWithLeftRightWall(GameEnums.Walls collidedWall, GameObject ball); 
	public static event OnBallCollidedWithLeftRightWall onBallCollideWithLeftRightWall;

	void Start()
	{
		_collider = this.gameObject.GetComponent<Collider2D>();
	}
	public void onCollide(Collision2D colidedObj2D)
	{
		string collidedObjTag = colidedObj2D.gameObject.tag;
		//Debug.Log("tag    " + collidedObjTag);
		if (collidedObjTag == GameEnums.Tag.ball.ToString())
		{
			BallHitOnWalls(colidedObj2D.gameObject);
		}
	}

	void BallHitOnWalls(GameObject ballObj)
	{
		if ( _wallName == GameEnums.Walls.right)
		{
            //Debug.Log("Ball Hit on wall in if ");
           // onBallCollideWithLeftRightWall(_wallName, ballObj);
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
