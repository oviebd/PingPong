﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class ObstaclePositioningHandler 
{

	public static void RespositioningGridItems(List<GameObject> obstacleList, float scale, GameObject parentObj)
	{
		ObstacleBoundaryDataClass obstacleBoundaryData = SetObstacleBoundaryData(scale);
		float yStartPos = (obstacleBoundaryData.minPosition.y + obstacleBoundaryData.maxPosition.y) / 2;

		List<GameObject> objs = new List<GameObject>();
		int colNumber = 0;

		for (int i = 0; i < obstacleList.Count; i++)
		{
			objs.Add(obstacleList[i]);
			int mod = ((i + 1) % obstacleBoundaryData.maxRowNumber);
		
			if ((mod == 0 && i != 0) || i == obstacleList.Count - 1)
			{
				//Debug.Log(i);
				DrawColumn(colNumber, obstacleBoundaryData.maxRowNumber, objs, yStartPos,scale);
				objs.Clear();
				objs = new List<GameObject>();
				colNumber = colNumber + 1;
			}
		}
		MoveParentObjBasedOnColumnNumber(colNumber,parentObj);
	}

	static void MoveParentObjBasedOnColumnNumber(int colNumber, GameObject parentObj)
	{
		// This function is need to made grid parebnt alignment center after creating cells;
		float offset = colNumber / 1.5f;
		Vector3 tempVec = parentObj.transform.position;
		tempVec.x = parentObj.transform.position.x - offset;
		parentObj.transform.position = tempVec;
	}
	public static ObstacleBoundaryDataClass SetObstacleBoundaryData(float scale)
	{
		float offset = 4.0f;
		float yMax = BoundaryController.instance.GetTopWallPosition().y - offset; 
		float yMin = BoundaryController.instance.GetBottomWallPosition().y + offset;
		float xMax = BoundaryController.instance.GetRightWallPosition().y - offset; 
		float xMin = BoundaryController.instance.GetLeftWallPosition().y + offset;

		//Debug.Log(yMax + " Y min : " + yMin + " xMax  " + xMax + " X Min " + xMin);

		ObstacleBoundaryDataClass boundary = new ObstacleBoundaryDataClass();

		boundary.minPosition = new Vector3(xMin, yMin, 0.0f);
		boundary.maxPosition = new Vector3(yMin, yMax, 0.0f);

		boundary.maxRowNumber = (int)((yMax - yMin) / scale);
		boundary.maxColumnNumber = (int)((xMax - xMin) / scale);

		return boundary;
	}

	public static void DrawColumn(int colNumber, int maxItemInACol, List<GameObject> items, float initialYpos,float scale)
	{
		float xPos = colNumber * scale;
		float yPos = initialYpos;

		float yUpSidePos = initialYpos;
		float yDownSidePos = initialYpos;

		for (int i = 0; i < maxItemInACol; i++)
		{
			if (i < items.Count)
			{
				if ((i % 2) == 0 && i != 0)
				{
					yDownSidePos = yDownSidePos - scale;
					yPos = yDownSidePos;
				}
				else if ((i % 2) != 0)
				{
					yUpSidePos = yUpSidePos + scale;
					yPos = yUpSidePos;
				}

				items[i].transform.position = new Vector3(xPos, yPos);
			}

		}
	}
}