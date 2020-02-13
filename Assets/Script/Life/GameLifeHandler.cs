﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLifeHandler : MonoBehaviour {

	public static GameLifeHandler instance;
	[SerializeField] private GameObject _lifePanel;
	[SerializeField] private Text _lifeCounterText;

	private int _gameLife = 4;

	void Awake()
	{
		if (instance == null)
			instance = this;
	}
	void Start () {

		_gameLife = GameDataHandler.instance.GetAmountOfLife();
		OnLifeUpdated();
	}

	public int GetCurrentLife()
	{
		return _gameLife;
	}
	public void AddLife(int amount)
	{
		_gameLife = _gameLife + amount;
		OnLifeUpdated();
	}
	public void DecreaseLife(int amount)
	{
		_gameLife = _gameLife - amount;
		if (_gameLife < 0)
			_gameLife = 0;
		OnLifeUpdated();
	}

    public void onBallCollidedWithLeftRightWall(GameEnums.Walls nextWall)
    {
        DecreaseLife(1);
        if (_gameLife <= 0)
            GameManager.instance.GameOver(false);  // LoseGame
        else
            GameManager.instance.ReviveGame();
    }

	void OnLifeUpdated()
	{
		GameDataHandler.instance.SetAmountOfLife(_gameLife);
		_lifeCounterText.text = _gameLife + "";
	}

}
