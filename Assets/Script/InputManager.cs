using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	private bool _isRightButtonPressed = false;
	private bool _isLeftButtonPressed = false;

	public delegate void LeftButtonPressed();
	public static event LeftButtonPressed onLeftButtonPressed;

	public delegate void RightButtonPressed();
	public static event RightButtonPressed onRightButtonPressed;

	private void Update()
	{
		if (_isRightButtonPressed)
			onRightButtonPressed();
		if (_isLeftButtonPressed)
			onLeftButtonPressed();

		if (Input.GetKey(KeyCode.RightArrow))
			onRightButtonPressed();
		if (Input.GetKey(KeyCode.LeftArrow))
			onLeftButtonPressed();
		
	}
	public void RightButtonPointerDown()
	{
		_isRightButtonPressed = true;
	}
	public void RightButtonPointerUp()
	{
		_isRightButtonPressed = false;
	}
	public void LeftButtonPointerDown()
	{
		_isLeftButtonPressed = true;
	}
	public void LeftButtonPointerUp()
	{
		_isLeftButtonPressed = false;
	}
	



}
