using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallBehaviour  {

	void OperationAfterCollision();
	void SetUp(BallBehaviour behaviour);
}
