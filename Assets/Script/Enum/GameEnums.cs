using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEnums  {

	public  enum PlayerEnum{	Player1_Right,Player2_Left}
	public enum Tag {ball ,wall,paddle,obstacle}
	public enum PaddleInput { inputUp, inputDown,none }
	public enum Walls { top, bottom,right,left }
	public enum ballType { type1,type2 }
    public enum ObstacleType { type1, bomb}

    public enum GameState { Idle,Running, Pause,Over }


}
