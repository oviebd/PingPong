using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLifeHandler : MonoBehaviour {

	public static GameLifeHandler instance;
	private int _gameLife = 2;

	void Awake()
	{
		if (instance == null)
			instance = this;
	}
	void Start () {
		//_gameLife = 1;
		BoundaryBehaviour.onBallCollideWithLeftRightWall += onBallCollidedWithLeftRightWall;
	}

	public int GetCurrentLife()
	{
		return _gameLife;
	}
	public void AddLife(int amount)
	{
		_gameLife = _gameLife + amount;
	}
	public void DecreaseLife(int amount)
	{
		_gameLife = _gameLife - amount;
	}

	public void onBallCollidedWithLeftRightWall(GameEnums.Walls nextWall)
	{
	    DecreaseLife(1);
		if (_gameLife <= 0)
			GameManager.instance.GameOver(false);  // LoseGame
		else
			GameManager.instance.ResetBallOnADirection(nextWall);


	}
	
	
	
}
