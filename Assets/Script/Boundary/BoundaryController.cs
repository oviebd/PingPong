using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour {

	public static BoundaryController instance;

	[SerializeField] private BoundaryBehaviour _leftWall;
	[SerializeField] private BoundaryBehaviour _rightWall;
	[SerializeField] private BoundaryBehaviour _topWall;
	[SerializeField] private BoundaryBehaviour _bottomWall;

	void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public  Vector2 GetLeftWallPosition()
	{
		return _leftWall.gameObject.transform.position;
	}
	public Vector2 GetRightWallPosition()
	{
		return _rightWall.gameObject.transform.position;
	}
	public Vector2 GetBottomWallPosition()
	{
		return _bottomWall.gameObject.transform.position;
	}
	public Vector2 GetTopWallPosition()
	{
		return _topWall.gameObject.transform.position;
	}


}
