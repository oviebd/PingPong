using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Rigidbody2D rb;

	void Start () {

		rb.velocity = new Vector2(6f, 6f);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
