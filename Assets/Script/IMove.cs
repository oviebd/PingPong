using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove  {

	void MoveUp();
	void MoveDown();
	void SetMovement(bool isMoveUp);
	void SetMoveEnableDisable(bool canMove);
	bool CanMove();
}
