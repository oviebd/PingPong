using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleBuilder  {

    void SetDestructionSound(AudioClip clip);
    void SetCollisionSound(AudioClip clip);
    void SetColor(Color color);
    void SetObstacleType(GameEnums.ObstacleType type);
    void SetValue(int value);
    void SetObstacleSprite(Sprite sprite);
    Obstacle getObstacle();

}
