using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour, IColliderEnter
{
	public void onCollide(Collision2D colidedObj2D)
	{
		Debug.Log("Collider name in boundary : " + colidedObj2D.gameObject.name);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
