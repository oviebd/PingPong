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
        obstacle.collisionClip = clip;
    }

    public void SetColor(Color color)
    {
        obstacle.outerImageColor = color;
    }

    public void SetDestructionSound()
    {
        
    }

    public void SetObstacleCollisionEffect()
    {
        obstacle.obstacleEffct = new GeneralObstacleCollisionEffect();
    }

    public void SetObstacleSprite()
    {
        Sprite sprite = Resources.Load<Sprite>("sprite/obstacle_type1");
        obstacle.outerImageSprite = sprite;
    }

    public void SetObstacleType()
    {
        obstacle.obstacleType = GameEnums.ObstacleType.normal;
    }

    public void SetValue(int value)
    {
        obstacle.value = value;
    }
}
