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
		DestroyAllObjectsInRadious();
    }

	void DestroyAllObjectsInRadious()
    {

		//InstantiatorHelper.InstantiateObject(destructionPartuicle, this.gameObject);

		destructionPartuicle.SetActive(true);

		float radious = 1;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(obstacleBehaviour.gameObject.transform.position, radious);

        for(int i = 0; i<colliders.Length;i++)
        {
			ObstacleEffectBaseClass effect = colliders[i].gameObject.GetComponent<ObstacleEffectBaseClass>();
			if (effect != null)
            {
				effect.DestroyObject();
            }
        }
    }
}
