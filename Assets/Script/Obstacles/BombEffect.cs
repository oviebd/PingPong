using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : ObstacleCollisionEffectClass, IObstacleCollisionEffect {

    public void DoCollisionAfterEffect(ObstacleBehaviour behaviour, Obstacle obstacle)
    {
        obstacleBehaviour = behaviour;
        obstacleClass = obstacle;
        Debug.Log(" Show Bomb Effect ....");
        DestroyAllObjectsInRadious();
    }

    public void PlaySound()
    {
       
    }
    public void DestroyObject()
    {

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
                behaviour.GetSpriteRenderer().sprite = null;
            }
        }
    }
}
