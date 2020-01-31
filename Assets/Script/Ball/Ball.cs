using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball  {

    public Vector2 initialVelocity { get; set; }
	public Vector2 maximumVelocity { get; set; }
	public Color color { get;set; }
	public GameEnums.ballType ballType  { get; set; }
    public bool isItFirstBall { get; set; }
    public IBallBehaviour ballBehaviour { get; set; }

    public Ball()
    {
        isItFirstBall = false;
    }
}
