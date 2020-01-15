using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour,IObstacleCollisionEffect {

    public void DoCollisionAfterEffect(ObstacleBehaviour behaviour, Obstacle obstacleClass)
    {
        Debug.Log(" Show Bomb Effect ....");
    }

    public void PlaySound()
    {
       
    }
    public void DestroyObject()
    {

    }
}
