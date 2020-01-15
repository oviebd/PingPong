using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public static ObstacleController instance;

	[SerializeField] public GameObject _parentObj;
	[SerializeField] public GameObject _obstaclePrefab;

	[SerializeField] public GameObject _topBoundary;
	[SerializeField] public GameObject _bottomBoundary;
	[SerializeField] public GameObject _leftBoundary;
	[SerializeField] public GameObject _rightBoundary;

    private float _scale = 1.1f;

	private List<GameObject> obstacleList = new List<GameObject>();
    private ObstacleBoundaryData obstacleBoundaryData;

    List<Color> colors = new List<Color>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start () {
        obstacleBoundaryData = new ObstacleBoundaryData();
        SpawnObstacle();
	}

    void SetColorList()
    {
        colors.Add(Color.cyan);
        colors.Add(Color.green);
        colors.Add(Color.grey);
        colors.Add(Color.blue);
        //colors.Add(Color.black);
    }

    void SpawnObstacle()
	{
		int objNumber =50;
        SetColorList();

		for (int i = 0; i < objNumber; i++)
		{
	    	GameObject obj =	InstantiatorHelper.InstantiateObject(_obstaclePrefab, _parentObj);

            Obstacle obstacle = GenerateObstacle(GameEnums.ObstacleType.bomb);
            obj.GetComponent<ObstacleBehaviour>().SetObstacle(obstacle);
            obstacleList.Add(obj);
		}

		RespositioningGridItems();
	}


    Obstacle GenerateObstacle(GameEnums.ObstacleType obstacleType)
    {
        ObstacleBuilder builder = new ObstacleBuilder();
        IObstacleBuilder obstacle;

        if (obstacleType == GameEnums.ObstacleType.type1)
            obstacle = new Obstacle_Type1();
        else
            obstacle = new Obstacle_Type2_Bomb();

        builder.BuildObstacle(obstacle);
       
        int colorIndex = Random.Range(0, colors.Count);
        if (colorIndex < colors.Count)
        {
            obstacle.SetColor(colors[colorIndex]);
        }
       
        return obstacle.getObstacle();
    }


    ObstacleBoundaryData SetObstacleBoundaryData()
    {
        float yMax = _topBoundary.transform.position.y;
        float yMin = _bottomBoundary.transform.position.y;
        float xMax = _rightBoundary.transform.position.x;
        float xMin = _leftBoundary.transform.position.x;

        ObstacleBoundaryData boundary = new ObstacleBoundaryData();

        boundary.minPosition = new Vector3(xMin,yMin,0.0f);
        boundary.maxPosition = new Vector3(yMin, yMax, 0.0f);

        boundary.maxRowNumber = (int)((yMax - yMin) / _scale);
        boundary.maxColumnNumber = (int)((xMax - xMin) / _scale);

        return boundary;
    }

	void RespositioningGridItems()
	{
        if(obstacleBoundaryData.maxPosition == Vector3.zero)
            obstacleBoundaryData = SetObstacleBoundaryData();

        float yStartPos = (obstacleBoundaryData.minPosition.y + obstacleBoundaryData.maxPosition.y) / 2;
        
        //Debug.Log("Y start pos " + yStartPos);
        //Debug.Log("Row ; " + maxRowNumber + " column : " + maxColumnNumber);

        List<GameObject> objs = new List<GameObject>();
		int colNumber = 0;

        for (int i = 0; i < obstacleList.Count; i++)
		{
			objs.Add(obstacleList[i]);
			int mod = ((i+1) % obstacleBoundaryData.maxRowNumber);
			//Debug.Log("  i : " + i + " % 10 " + mod);
			if ( (mod ==0 && i != 0) || i == obstacleList.Count-1)
			{
				//Debug.Log(i);
				DrawColumn(colNumber, obstacleBoundaryData.maxRowNumber, objs, yStartPos);
				objs.Clear();
				objs = new List<GameObject>();
				colNumber = colNumber + 1;
			}
		}

        MoveParentObjBasedOnColumnNumber(colNumber);
    }


    void MoveParentObjBasedOnColumnNumber(int colNumber)
    {
        // This function is need to made grid parebnt alignment center after creating cells;
        float offset = colNumber / 2;
        Vector3 tempVec = _parentObj.transform.position;
        tempVec.x = _parentObj.transform.position.x - offset;
        _parentObj.transform.position = tempVec;
    }


	void DrawColumn(int colNumber,int maxItemInACol,List<GameObject> items,float initialYpos)
	{
		float xPos = colNumber * _scale;
        float yPos = initialYpos;

        float yUpSidePos = initialYpos;
        float yDownSidePos = initialYpos;

        for (int i=0; i< maxItemInACol; i++)
		{
			if ( i < items.Count)
			{
                if( (i % 2) == 0 && i != 0)
                {
                    yDownSidePos = yDownSidePos - _scale;
                    yPos = yDownSidePos;
                }
                else if ((i % 2) != 0)
                {
                    yUpSidePos = yUpSidePos + _scale;
                    yPos = yUpSidePos;
                }

                items[i].transform.position = new Vector3(xPos, yPos);
			}

		}
	}

    class ObstacleBoundaryData
    {
        public Vector3 minPosition;
        public Vector3 maxPosition;
        public int maxColumnNumber;
        public int maxRowNumber;

        public ObstacleBoundaryData()
        {
            minPosition = Vector3.zero;
            maxPosition = Vector3.zero;
            maxColumnNumber = 0;
            maxRowNumber = 0;
        }
    }

}
