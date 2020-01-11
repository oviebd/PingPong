using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneAnimationHandler : MonoBehaviour {

	public static GameSceneAnimationHandler instance;

	[SerializeField] CountTextAnimation _countTextAnimation;

	void Start()
	{
		if (instance == null)
			instance = this;
	}

	public void PlayCountAnimation(int countNumber)
	{
		_countTextAnimation.ShowCountTextWithAnimation(countNumber);
	}


}
