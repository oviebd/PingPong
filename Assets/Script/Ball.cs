using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour,IColliderEnter {

	public Rigidbody2D rb;
	private Vector2 _initialVelocity = new Vector2(6.0f,6.0f);
	private Vector2 _maxVelocity = new Vector2(10.0f,10.0f);

	void Start()
	{
		rb.velocity = _initialVelocity;
	}

	public void onCollide(Collision2D colidedObj2D)
	{
		//rb.sharedMaterial.bounciness = rb.sharedMaterial.bounciness + 1;
		if ( Mathf.Abs (rb.velocity.x) <=  _maxVelocity.x && Mathf.Abs (rb.velocity.y) <= _maxVelocity.y )
			rb.velocity = rb.velocity * (1.1f);

		//Debug.Log(rb.velocity);

	}

	

}
