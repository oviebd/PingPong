using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerCounter : MonoBehaviour {

	[SerializeField] private UnityEvent onTrigger = new UnityEvent();
	private float _lastCollisionTime;
	public float thersHoldtime = 1.0f;


	public void Start()
	{
		_lastCollisionTime = Time.time;
	}

	bool isCollisionThreshHoldFinished()
	{
		if ((Time.time - _lastCollisionTime) >= thersHoldtime)
		{
			_lastCollisionTime = Time.time;
			return true;
		}
		return false;
	}

	public void CheckTimeCounter()
	{

	}

}
