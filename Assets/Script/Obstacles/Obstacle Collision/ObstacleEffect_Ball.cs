using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffect_Ball : ObstacleEffectBaseClass, IObstacleCollisionEffect
{
	public void SetObstacleBehaviour(ObstacleBehaviour behaviour)
	{
		obstacleBehaviour = behaviour;
		_obstacle = behaviour.GetObstacleClass();
	}
	public void DoCollisionAfterEffect()
	{
		PlaySound(_obstacle.collisionClip);
		BallController.instance.InstantiateExtraBall(GenerateBallTypeRandomly());
		DestroyObject();
	}

	

	GameEnums.ballType GenerateBallTypeRandomly()
	{
		int randomRange = Random.Range(0, 100);
		GameEnums.ballType type = GameEnums.ballType.NormalBall_Type1;

		if (randomRange < 80)
			type = GameEnums.ballType.NormalBall_Type1;
		else if (randomRange >= 80 && randomRange <= 100)
			type = GameEnums.ballType.SpecialBall_Type2;
	
		return type;
	}

}
