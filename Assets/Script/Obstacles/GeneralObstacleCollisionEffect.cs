using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObstacleCollisionEffect : MonoBehaviour, IObstacleCollisionEffect
{
    public void DoCollisionAfterEffect()
    {
        Debug.Log("Normal effect will play");
    }
}
