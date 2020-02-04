using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleCollisionEffect  {
	void SetObstacleBehaviour(ObstacleBehaviour behaviour);
    void DoCollisionAfterEffect();
}
