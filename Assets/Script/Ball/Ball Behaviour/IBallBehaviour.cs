using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallBehaviour  {

	void OperationAfterCollision(Collision2D collision2D);
	void SetUp(BallBehaviour behaviour);
}
