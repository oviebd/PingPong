using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle {

    public Color  outerImageColor { get; set; }
    public Sprite outerImageSprite { get; set; }
    public Color  innerImageColor { get; set; }
    public Sprite innerImageSprite { get; set; }

    public AudioClip collisionClip { get; set; }
    public AudioClip destructionClip { get; set; }
    public int value { get; set; }
    public GameEnums.ObstacleType obstacleType { get; set; }
    public IObstacleCollisionEffect obstacleEffct { get; set; }
}
