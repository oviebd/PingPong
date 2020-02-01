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

    [SerializeField] private List<GameObject> _obstaclePrefabList;

    private float _scale = 1.8f;
	private List<GameObject> obstacleList = new List<GameObject>();

    List<Color> colors = new List<Color>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start () {
		BoundaryController.OnBoundaryRepositioningCompleted += SpawnObstacle;
	}

	private void OnDestroy()
	{
		BoundaryController.OnBoundaryRepositioningCompleted -= SpawnObstacle;
	}

	void SpawnObstacle()
	{
		int objNumber =50;

		for (int i = 0; i < objNumber; i++)
		{
            GameObject obstacle = GetSpecificObstacle(GameEnums.ObstacleType.type1);
	    	GameObject obj =  InstantiatorHelper.InstantiateObject(obstacle.gameObject, _parentObj);
            
            obj.GetComponent<ObstacleBehaviour>().SetUp();
            obstacleList.Add(obj);
		}

		ObstaclePositioningHandler.RespositioningGridItems(obstacleList, _scale, _parentObj);
	}

    GameObject GetSpecificObstacle(GameEnums.ObstacleType type)
    {
        for(int i = 0; i< _obstaclePrefabList.Count;i++){
            ObstacleBehaviour obstacle = _obstaclePrefabList[i].GetComponent<ObstacleBehaviour>();
            if (obstacle!= null && type == obstacle.obstacleType)
                return _obstaclePrefabList[i];
        }

        return null;
    }

  
}
