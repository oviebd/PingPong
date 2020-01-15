using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour,IObstacleCollisionEffect {

    public void DoCollisionAfterEffect()
    {
        Debug.Log(" Show Bomb Effect ....");
    }
}
