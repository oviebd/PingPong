using UnityEngine;
using UnityEngine.Events;

public class ColliderOverlap : MonoBehaviour {

    [SerializeField] private UnityEvent onTrigger = new UnityEvent();
    [SerializeField] private LayerMask layerMask = new LayerMask();


    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.layer == layerMask)
        {
            Debug.Log("Collided ........... ");
            if(onTrigger!=null)
                onTrigger.Invoke();
        }
    }
}
