using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleCollisionEffect  {

    void DoCollisionAfterEffect(ObstacleBehaviour behaviour);
    void PlaySound();
    void DestroyObject();
}
