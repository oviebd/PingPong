using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObstacleCollisionEffect : ObstacleEffectBaseClass, IObstacleCollisionEffect
{
	public void SetObstacleBehaviour(ObstacleBehaviour behaviour)
	{
		obstacleBehaviour = behaviour;
		_obstacle = behaviour.GetObstacleClass();
	}

    public void DoCollisionAfterEffect()
    {
		//PlaySound(_obstacle.collisionClip);
		//DestroyObject();
		OperateObstacleCollisionEffect();

	}
}
