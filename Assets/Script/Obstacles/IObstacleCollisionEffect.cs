using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleCollisionEffect  {

    void DoCollisionAfterEffect(ObstacleBehaviour behaviour, Obstacle obstacleClass);
    void PlaySound();
    void DestroyObject();


}
