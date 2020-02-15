using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGraphicsController : MonoBehaviour
{
    public static GameGraphicsController instance;

    [SerializeField] private GameObject _ballParentObject;
    [SerializeField] private GameObject _obstacleParentObject;
    [SerializeField] private GameObject _paddleParentObject;
    [SerializeField] private GameObject _graphicsRootObject;


    private void Awake()
    {
        if (instance == null)
            instance = this;

		
	}

	private void Start()
	{
		_paddleParentObject.SetActive(false);
	}

	public void PrepareGraphicsForCounterAnimation(bool isFinishedAnimation)
    {
        _obstacleParentObject.SetActive(isFinishedAnimation);
        _paddleParentObject.SetActive(isFinishedAnimation);
        _ballParentObject.SetActive(isFinishedAnimation);
        GameSceneUIManager.instance.ShowHideAllGameUi(isFinishedAnimation);
    }
}
