using UnityEngine;
using UnityEngine.Events;

public class ColliderOverlap : MonoBehaviour {

  //  [SerializeField] private UnityEvent onTrigger = new UnityEvent();
    [SerializeField] private LayerMask layerMask = new LayerMask();

    private void OnCollisionEnter2D(Collision2D collision)
	{
		Collideable collidable = this.gameObject.GetComponent<Collideable>();
		if (collidable != null)
			collidable.onCollide(collision);
		/*if ( collision.gameObject.layer == (int)layerMask)
        {
			if (onTrigger!=null)
                onTrigger.Invoke();
	}*/
	}
}
