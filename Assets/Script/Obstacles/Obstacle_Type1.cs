using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Type1 : IObstacleBuilder
{
    Obstacle obstacle = new Obstacle();

    public Obstacle getObstacle()
    {
        return obstacle;
    }

    public void SetCollisionSound(AudioClip clip)
    {
        obstacle._collisionClip = clip;
    }

    public void SetColor(Color color)
    {
        throw new System.NotImplementedException();
    }

    public void SetDestructionSound(AudioClip clip)
    {
        throw new System.NotImplementedException();
    }

    public void SetObstacleSprite(Sprite sprite)
    {
        throw new System.NotImplementedException();
    }

    public void SetObstacleType(GameEnums.ObstacleType type)
    {
        throw new System.NotImplementedException();
    }

    public void SetValue(int value)
    {
        throw new System.NotImplementedException();
    }
}
