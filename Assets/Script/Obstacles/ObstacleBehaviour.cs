using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleBehaviour : ObstacleBaseClass, IColliderEnter
{

	//public delegate void OnBallCollideWithObstacle(int score);
	//public static event OnBallCollideWithObstacle updateScoreManagerData;

    private IObstacleCollisionEffect _obstacleCollisionEffect;

    public void SetUp()
    {
        InitializeObstacle();
        _obstacleCollisionEffect = gameObject.GetComponent<IObstacleCollisionEffect>();
		_obstacleCollisionEffect.SetObstacleBehaviour(this);
	}

    public void onCollide(Collision2D colidedObj2D)
    {
        if(_obstacleCollisionEffect != null)
            _obstacleCollisionEffect.DoCollisionAfterEffect();
    }

	
}
