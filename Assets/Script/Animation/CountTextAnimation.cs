﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTextAnimation : PanelUI {

	[SerializeField] private Animator _anim;
	[SerializeField] private Text _countText;

	private float _perAnimationTime = 0.5f;

	public delegate void onCountAnimationFinished();
	public static event onCountAnimationFinished OnCountAnimationFinished;


	public void ShowCountTextWithAnimation( int countNum )
	{
		ShowPanel();
		StartCoroutine(AnimateCounterText(3));
	}

	public IEnumerator AnimateCounterText(int countNumber)
	{
		for(int i=countNumber; i >= 0; i--)
		{
			if( i > 0 )
				_countText.text = i + "";
			else
				_countText.text = "GO";

			yield return new WaitForSeconds(_perAnimationTime);
		}
		OnCountAnimationFinished();
		HidePanel();
	}
	
}
