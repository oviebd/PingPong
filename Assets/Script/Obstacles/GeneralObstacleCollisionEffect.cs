﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObstacleCollisionEffect : MonoBehaviour, IObstacleCollisionEffect
{
    ObstacleBehaviour _obstacleBehaviour;
    Obstacle _obstacle;
    float destroyTime = .5f;

    public void DoCollisionAfterEffect(ObstacleBehaviour behaviour, Obstacle obstacleClass)
    {
        _obstacleBehaviour = behaviour;
        _obstacle = obstacleClass;

        PlaySound();
        DestroyObject();

        BallController.instance.InstantiateBall(GameEnums.ballType.NormalBall_Type1);
    }

    public void PlaySound()
    {
        _obstacleBehaviour.GetAudioSource().clip = _obstacle._collisionClip;
        _obstacleBehaviour.GetAudioSource().Stop();
        _obstacleBehaviour.GetAudioSource().Play();
    }

    public void DestroyObject()
    {
        _obstacleBehaviour.getCollider().enabled = false;
        _obstacleBehaviour.GetSpriteRenderer().enabled = false;

        Destroy(_obstacleBehaviour.gameObject, destroyTime);
    }
}
