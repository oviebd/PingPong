using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEnums  {

	public  enum PlayerEnum{	Player1_Right,Player2_Left}
	public enum Tag {ball ,wall,paddle,obstacle}
	public enum PaddleInput { inputUp, inputDown,none }
	public enum Walls { top, bottom,right,left }
	public enum ballType { NormalBall_Type1,SpecialBall_Type2 }
    public enum ObstacleType { normal,life, bomb,spawnBall}

    public enum GameState { Idle,Running, Pause,Over,LevelUp,NewGame,Resume,Revive }


}
