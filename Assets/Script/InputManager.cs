using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	private bool _isUpButtonClicked = false;
	private bool _isDownButtonClicked = false;

	public delegate void DownButtonPressed();
	public static event DownButtonPressed onDownButtonPressed;

	public delegate void UpButtonPressed();
	public static event UpButtonPressed onUpButtonPressed;

	private void Update()
	{
		if (_isUpButtonClicked)
			onUpButtonPressed();
		if (_isDownButtonClicked)
			onDownButtonPressed();

		if (Input.GetKey(KeyCode.UpArrow))
			onUpButtonPressed();
		if (Input.GetKey(KeyCode.DownArrow))
			onDownButtonPressed();
		
	}
	public void UpButtonPointerDown()
	{
		_isUpButtonClicked = true;
	}
	public void UpButtonPointerUp()
	{
		_isUpButtonClicked = false;
	}
	public void DownButtonPointerDown()
	{
		_isDownButtonClicked = true;
	}
	public void DownButtonPointerUp()
	{
		_isDownButtonClicked = false;
	}
	



}
