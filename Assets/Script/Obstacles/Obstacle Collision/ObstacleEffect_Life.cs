using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffect_Life : ObstacleEffectBaseClass, IObstacleCollisionEffect
{

	public void DoCollisionAfterEffect(ObstacleBehaviour behaviour)
	{
		obstacleBehaviour = behaviour;
		_obstacle = behaviour.GetObstacleClass();

		PlaySound(_obstacle.collisionClip);
	    GameLifeHandler.instance.AddLife(1);
		DestroyObject();
	}
}

