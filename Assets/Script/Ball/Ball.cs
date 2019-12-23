using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball  {
	public Vector2 initialVelocity { get; set; }
	public Vector2 maximumVelocity { get; set; }
	public Color color { get;set; }
	public GameEnums.ballType ballType  { get; set; }
}
