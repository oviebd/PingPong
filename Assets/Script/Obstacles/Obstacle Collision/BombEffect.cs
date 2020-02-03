using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect :ObstacleEffectBaseClass, IObstacleCollisionEffect {

    public void DoCollisionAfterEffect(ObstacleBehaviour behaviour)
    {
		obstacleBehaviour = behaviour;
		_obstacle = behaviour.GetObstacleClass();
		DestroyAllObjectsInRadious();
    }

    void DestroyAllObjectsInRadious()
    {
        float radious = 1;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(obstacleBehaviour.gameObject.transform.position, radious);

        for(int i = 0; i<colliders.Length;i++)
        {
            Debug.Log(colliders[i].gameObject.name);
            ObstacleBehaviour behaviour = colliders[i].gameObject.GetComponent<ObstacleBehaviour>();
            if (behaviour != null)
            {
                behaviour.GetInnerSpriteRenderer().sprite = null;
            }
        }
    }
}
