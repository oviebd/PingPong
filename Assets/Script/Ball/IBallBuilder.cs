using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallBuilder  {
	void SetInitialVelocity();
	void SetMaxVelocity();
	void SetColor(Color color);
	void SetBallType();
    void SetBallBehaviour();
	Ball getBall();
}
