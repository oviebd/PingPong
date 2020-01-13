using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour {

	public static BoundaryController instance;

    [SerializeField] private Camera _mainCamera;

    [SerializeField] private BoundaryBehaviour _leftWall;
	[SerializeField] private BoundaryBehaviour _rightWall;
	[SerializeField] private BoundaryBehaviour _topWall;
	[SerializeField] private BoundaryBehaviour _bottomWall;

    [SerializeField] private GameObject _leftPaddlePosition;
    [SerializeField] private GameObject _rightPaddlePosition;

	void Awake()
	{
		if (instance == null)
			instance = this;
	}

    private void Start()
    {
       Invoke( "ResetBoundaryPositions",0.3f);
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

    void ResetBoundaryPositions()
    {
        float heightOffset = 0.5f; 
        
        Vector3 worldPosWidth = GetWidthInWorldSpace();
        Vector3 worldPosHeight = GetHeightInWorldPosition();

        _topWall.GetCollider().size      = new Vector2(worldPosWidth.x *2, 1.0f);
        _topWall.GetCollider().offset    = new Vector2(0f, worldPosHeight.y);

        _bottomWall.GetCollider().size   = new Vector2(worldPosWidth.x * 2, 1.0f);
        _bottomWall.GetCollider().offset = new Vector2(0f, ( worldPosHeight.y * (-1)));

        _leftWall.GetCollider().size     = new Vector2(1.0f, worldPosHeight.y*2);
        _leftWall.GetCollider().offset   = new Vector2(worldPosWidth.x * (-1) , 0);

        _rightWall.GetCollider().size = new Vector2(1.0f, worldPosHeight.y * 2);
        _rightWall.GetCollider().offset = new Vector2(worldPosWidth.x, 0);

        ResetPaddlePosition();

    }

    void ResetPaddlePosition()
    {
        Vector3 worldPosWidth = GetWidthInWorldSpace();
        Vector3 worldPosHeight = GetHeightInWorldPosition();
        float offset = 1.0f;
        _leftPaddlePosition.transform.position = new Vector3( (-1) * worldPosWidth.x + offset ,0,0);
        _rightPaddlePosition.transform.position = new Vector3( worldPosWidth.x - offset , 0, 0);
    }

    public Vector3 GetWidthInWorldSpace()
    {
        Vector2 widthVec = new Vector2(Screen.width, 0f);
        Vector3 worldPosWidth = _mainCamera.ScreenToWorldPoint(new Vector3(widthVec.x, widthVec.y, _mainCamera.nearClipPlane));
//        Debug.Log("World Pos WIdth : " + worldPosWidth);
        return worldPosWidth;
    }

    public Vector3 GetHeightInWorldPosition()
    {
        Vector2 heightVec = new Vector2(0, Screen.height);
        Vector3 worldPosHeight = _mainCamera.ScreenToWorldPoint(new Vector3(heightVec.x, heightVec.y, _mainCamera.nearClipPlane));
      //  Debug.Log("World Pos Height : " + worldPosHeight);
        return worldPosHeight;
    }


}
