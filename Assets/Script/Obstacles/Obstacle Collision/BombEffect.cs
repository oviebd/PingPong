using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect :ObstacleEffectBaseClass, IObstacleCollisionEffect {

    [SerializeField] private GameObject destructionPartuicle;

    public void SetObstacleBehaviour(ObstacleBehaviour behaviour)
	{
		obstacleBehaviour = behaviour;
		_obstacle = behaviour.GetObstacleClass();
	}

    public void DoCollisionAfterEffect()
    {
        PlaySound(_obstacle.collisionClip);
        DestroyObject();
        DestroyAllObjectsInRadious();
	}

	void DestroyAllObjectsInRadious()
    {
		destructionPartuicle.SetActive(true);
		float radious = 1;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(obstacleBehaviour.gameObject.transform.position, radious);
       
        for(int i = 0; i<colliders.Length;i++)
        {
            IObstacleCollisionEffect effect = colliders[i].gameObject.GetComponent<IObstacleCollisionEffect>();
            if (effect != this && effect != null )
            {
                effect.DoCollisionAfterEffect();
            }
          
        }
    }
}
