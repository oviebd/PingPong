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
		BallController.instance.InstantiateExtraBall(GenerateBallTypeRandomly());
		ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
		if (particleSystem != null)
			Destroy(particleSystem.gameObject);

		OperateObstacleCollisionEffect();
	}

	GameEnums.ballType GenerateBallTypeRandomly()
	{
		int randomRange = Random.Range(0, 100);
		GameEnums.ballType type;

		if (randomRange < 50)
			type = GameEnums.ballType.NormalBall_Type1;
		else 
			type = GameEnums.ballType.SpecialBall_Type2;
	
		return type;
	}

}
