using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

	[SerializeField] public GameObject _parentObj;
	[SerializeField] public GameObject _obstaclePrefab;

	[SerializeField] public GameObject _topBoundary;
	[SerializeField] public GameObject _bottomBoundary;
	[SerializeField] public GameObject _leftBoundary;
	[SerializeField] public GameObject _rightBoundary;

	private List<GameObject> obstacleList = new List<GameObject>();
	void Start () {
		SpawnObstacle();
	}

	void SpawnObstacle()
	{
		int objNumber =50;

		for (int i = 0; i < objNumber; i++)
		{
	    	GameObject obj =	InstantiatorHelper.InstantiateObject(_obstaclePrefab, _parentObj);
			obstacleList.Add(obj);
		}

		ResetPosition();
	}


	void ResetPosition()
	{
		float yMax  = _topBoundary.transform.position.y;
		float yMin   = _bottomBoundary.transform.position.y;
		float xMax  = _rightBoundary.transform.position.x;
		float xMin   = _leftBoundary.transform.position.x;

	//	Debug.Log("Max X,Y : " + xMax + " , " +  yMax  );
		//Debug.Log("Min X,Y : " + xMin + " , " + yMin);

		Vector3 perItemSize = _obstaclePrefab.transform.localScale;
		int maxRowNumber = (int) (  (yMax - yMin) / perItemSize.y );
		int maxColumnNumber = (int)((xMax - xMin) / perItemSize.x);

		//Debug.Log("Row ; " + maxRowNumber + " column : " + maxColumnNumber);
		
		List<GameObject> objs = new List<GameObject>();
		int colNumber = 0;
		for (int i = 0; i < obstacleList.Count; i++)
		{
			objs.Add(obstacleList[i]);
			int mod = ((i+1) % maxRowNumber);
			//Debug.Log("  i : " + i + " % 10 " + mod);
			if ( (mod ==0 && i != 0) || i == obstacleList.Count-1)
			{
				Debug.Log(i);
				DrawColumn(colNumber, maxRowNumber, objs, yMin);
				objs.Clear();
				objs = new List<GameObject>();
				colNumber = colNumber + 1;
			}
			
		}
	}

	void DrawColumn(int colNumber,int maxItemInACol,List<GameObject> items,float initialYpos)
	{
		float xPos = colNumber * _obstaclePrefab.transform.localScale.x;

		for (int i=0; i< maxItemInACol; i++)
		{
			if ( i < items.Count)
			{
				float yPos = initialYpos + i * _obstaclePrefab.transform.localScale.y;
				Vector3 newPos = new Vector3(xPos, yPos);
				Debug.Log(newPos);
				items[i].transform.position = newPos ;
			}

		}
	}

}
