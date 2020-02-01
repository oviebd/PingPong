using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBoundaryDataClass
{
	public Vector3 minPosition;
	public Vector3 maxPosition;
	public int maxColumnNumber;
	public int maxRowNumber;

	public ObstacleBoundaryDataClass()
	{
		minPosition = Vector3.zero;
		maxPosition = Vector3.zero;
		maxColumnNumber = 0;
		maxRowNumber = 0;
	}
}
    
