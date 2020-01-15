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

    public void SetCollisionSound()
    {  
        AudioClip clip = Resources.Load<AudioClip>("sounds/obstacle_type1_collision");
        obstacle._collisionClip = clip;
    }

    public void SetColor(Color color)
    {
        obstacle.color = color;
    }

    public void SetDestructionSound()
    {
        
    }

    public void SetObstacleSprite()
    {
        Sprite sprite = Resources.Load<Sprite>("sprite/obstacle_type1");
        obstacle.sprite = sprite;
    }

    public void SetObstacleType()
    {
        obstacle.obstacleType = GameEnums.ObstacleType.type1;
    }

    public void SetValue(int value)
    {
        obstacle.value = value;
    }
}
