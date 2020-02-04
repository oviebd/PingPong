using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffect_Life : ObstacleEffectBaseClass, IObstacleCollisionEffect
{
	public void SetObstacleBehaviour(ObstacleBehaviour behaviour)
	{
		obstacleBehaviour = behaviour;
		_obstacle = behaviour.GetObstacleClass();
	}
	public void DoCollisionAfterEffect()
	{
		PlaySound(_obstacle.collisionClip);
	    GameLifeHandler.instance.AddLife(1);
		DestroyObject();
	}

	
}

