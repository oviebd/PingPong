using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLifeHandler : MonoBehaviour {

	public static GameLifeHandler instance;
	[SerializeField] private GameObject _lifePanel;
	[SerializeField] private Text _lifeCounterText;

	private int _gameLife = 40;

	void Awake()
	{
		if (instance == null)
			instance = this;
	}
	void Start () {
		UpdateLifeUI();
	}

	public int GetCurrentLife()
	{
		return _gameLife;
	}
	public void AddLife(int amount)
	{
		_gameLife = _gameLife + amount;
		UpdateLifeUI();
	}
	public void DecreaseLife(int amount)
	{
		_gameLife = _gameLife - amount;
		UpdateLifeUI();
	}

    public void onBallCollidedWithLeftRightWall(GameEnums.Walls nextWall)
    {
        DecreaseLife(1);
        if (_gameLife <= 0)
            GameManager.instance.GameOver(false);  // LoseGame
        else
            GameManager.instance.ResetBallOnADirection(nextWall);
    }

	void UpdateLifeUI()
	{
		_lifeCounterText.text = _gameLife + "";
	}

}
