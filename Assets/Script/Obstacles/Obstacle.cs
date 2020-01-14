using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle {

    public Color color { get; set; }
    public Sprite sprite { get; set; }
    public AudioClip _collisionClip { get; set; }
    public AudioClip _destructionClip { get; set; }
    public int value { get; set; }
    public GameEnums.ObstacleType obstacleType { get; set; }

}
