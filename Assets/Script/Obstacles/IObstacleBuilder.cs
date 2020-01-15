using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleBuilder  {

    void SetDestructionSound();
    void SetCollisionSound();
    void SetColor(Color color);
    void SetObstacleType();
    void SetValue(int value);
    void SetObstacleSprite();
    void SetObstacleCollisionEffect();
    Obstacle getObstacle();

}
