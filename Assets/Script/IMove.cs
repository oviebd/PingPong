using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove  {

	void Movement(bool isMoveUp);
	void StopMovement();
	void StartMovement();
	bool CanMove();
}
