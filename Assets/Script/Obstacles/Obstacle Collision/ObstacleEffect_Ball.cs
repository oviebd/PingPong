using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffect_Ball : ObstacleEffectBaseClass, IObstacleCollisionEffect
{
	public void DoCollisionAfterEffect(ObstacleBehaviour behaviour)
	{
		obstacleBehaviour = behaviour;
		_obstacle = behaviour.GetObstacleClass();

		PlaySound(_obstacle.collisionClip);
		BallController.instance.InstantiateBall(GameEnums.ballType.NormalBall_Type1);
		DestroyObject();

	}
}
