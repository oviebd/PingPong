using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObstacleCollisionEffect : ObstacleEffectBaseClass, IObstacleCollisionEffect
{

    public void DoCollisionAfterEffect(ObstacleBehaviour behaviour)
    {
        obstacleBehaviour = behaviour;
        _obstacle = behaviour.GetObstacleClass();

        PlaySound(_obstacle.collisionClip);
        DestroyObject();

       // BallController.instance.InstantiateBall(GameEnums.ballType.NormalBall_Type1);
    }
}
