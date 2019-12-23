using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Paddle leftPaddle;
    public Paddle rightPaddle;
    [SerializeField] private  GameObject _ballPrefab;
	[SerializeField] private GameObject _ballParent;

    // Use this for initialization
	void Start () {
		BoundaryController.BallCollisionWithLeftRightWall += BallCollisionWithLeftRightWall;
		//GameObject ballObj = InstantiatorHelper.InstantiateObject(_ballPrefab, _ballParent);
		//FindObjectOfType<BallController>().InstantiateBall();
	}

	public void BallCollisionWithLeftRightWall(GameEnums.PlayerEnum winnerPlayer)
	{
		Debug.Log("Winner Player is ': " + winnerPlayer);
	}



}
