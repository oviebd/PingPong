using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class ObstaclePositioningHandler 
{

	public static void RespositioningGridItems(List<GameObject> obstacleList, float scale, GameObject parentObj)
	{
		ObstacleBoundaryDataClass obstacleBoundaryData = SetObstacleBoundaryData(scale);
		float xStartPos = (obstacleBoundaryData.minPosition.x + obstacleBoundaryData.maxPosition.x) / 2;
		//xStartPos = obstacleBoundaryData.maxPosition.y;

        List<GameObject> objs = new List<GameObject>();
		int rowNumber = 0;

		for (int i = 0; i < obstacleBoundaryData.maxRowNumber; i++)
		{

            for (int j = 0; j < obstacleBoundaryData.maxColumnNumber; j++)
            {
				int a =  ( i * obstacleBoundaryData.maxColumnNumber) + j;

                if (a < obstacleList.Count)
                {
					objs.Add(obstacleList[a]);
                }
				//i = i + 1;
            }

			DrawRow (i, obstacleBoundaryData.maxColumnNumber, objs, xStartPos, obstacleBoundaryData.maxPosition.y, scale);

			objs.Clear();
			objs = new List<GameObject>();
			rowNumber = rowNumber + 1;
		}
	}

	public static ObstacleBoundaryDataClass SetObstacleBoundaryData(float scale)
	{
		float xOffset = scale * 1.0f;
		float yOffset = 2.0f;
		float yMax = BoundaryController.instance.GetTopWallPosition().y - yOffset;
		float yMin = BoundaryController.instance.GetBottomWallPosition().y + yOffset;
		float xMax = BoundaryController.instance.GetRightWallPosition().x - xOffset;
		float xMin = BoundaryController.instance.GetLeftWallPosition().x + xOffset;

		//Debug.Log(yMax + " Y min : " + yMin + " xMax  " + xMax + " X Min " + xMin);

		ObstacleBoundaryDataClass boundary = new ObstacleBoundaryDataClass();

		boundary.minPosition = new Vector3(xMin, yMin, 0.0f);
		boundary.maxPosition = new Vector3(yMin, yMax, 0.0f);

		boundary.maxColumnNumber = (int)((xMax - xMin) / scale);
		boundary.maxRowNumber = (int)((yMax - yMin) / scale);
		//Debug.Log( "col " +  boundary.maxColumnNumber  + "  row : " + boundary.maxRowNumber);
		return boundary;
	}

	public static void DrawRow(int rowNumber, int maxItemInARow, List<GameObject> items, float initialXpos, float initialYpos, float scale)
	{
		float xPos = 0; 
		float yPos = initialYpos - (rowNumber * scale);

		//Debug.Log("init x pos : " + initialXpos + " max item in row " + maxItemInARow);

		float xRightSidePos = 0;
		float xLeftSidePos = 0;

		for (int i = 0; i < maxItemInARow; i++)
		{
			if (i < items.Count)
			{
				if ((i % 2) == 0 && i != 0)
				{
					xLeftSidePos = xLeftSidePos + scale;
					xPos = xLeftSidePos;
				}
				else if ((i % 2) != 0)
				{
					xRightSidePos = xRightSidePos - scale;
					xPos = xRightSidePos;
                }
				//Debug.Log("i is : " + i + " val is :  " + new Vector3(xPos, yPos));
				items[i].transform.position = new Vector3(xPos, yPos);
			}

		}
	}

	/*public static void DrawColumn(int colNumber, int maxItemInACol, List<GameObject> items, float initialXpos, float initialYpos, float scale)
	{
		//	float xPos = colNumber * scale;
		float xPos = ( colNumber * scale )  + initialXpos ;
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
	}*/



}
