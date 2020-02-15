using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public static ObstacleController instance;

	[SerializeField] public GameObject _parentObj;
	[SerializeField] public GameObject _obstaclePrefab;

    [SerializeField] private List<GameObject> _obstaclePrefabList;

    private float _scale = 1f;
	private List<GameObject> obstacleList = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start () {
	//	BoundaryController.OnBoundaryRepositioningCompleted += SpawnObstacle;
	}

	private void OnDestroy()
	{
		//BoundaryController.OnBoundaryRepositioningCompleted -= SpawnObstacle;
	}

	public void PrepareObstacleControllerForNewGame()
	{
		DestroyAllObstacle();
		SpawnObstacle();
	}
	void SpawnObstacle()
	{
		DestroyAllObstacle();
		int maxPointInLevel = 0;
		int objNumber = GameDataGeneratorHandler.GenerateObstacleBasedOnLevelNumber();
		objNumber = 100;
		for (int i = 0; i < objNumber; i++)
		{
			GameObject obstacle = GetSpecificObstacle(GenerateRandomObstacleType());
			GameObject obj =  InstantiatorHelper.InstantiateObject(obstacle.gameObject, _parentObj);

			ObstacleBehaviour behaviour = obj.GetComponent<ObstacleBehaviour>();
			if ( behaviour != null)
			{
				behaviour.SetUp();
				maxPointInLevel = maxPointInLevel + behaviour.GetObstacleClass().value;
			}
            obstacleList.Add(obj);
		}
		ObstaclePositioningHandler.RespositioningGridItems(obstacleList, _scale, _parentObj);
		//maxPointInLevel = maxPointInLevel - 10;
		WinningConditionHandler.instance.SetWinningPoint( maxPointInLevel );
	}

	GameEnums.ObstacleType GenerateRandomObstacleType()
	{
		int randomRange = Random.Range(0, 100);
		GameEnums.ObstacleType type = GameEnums.ObstacleType.normal;

		if (randomRange < 75)
			type = GameEnums.ObstacleType.normal;
		else if( randomRange >= 75  && randomRange < 85 )
			type = GameEnums.ObstacleType.life;
		else if (randomRange >= 85 && randomRange < 95)
			type = GameEnums.ObstacleType.spawnBall;
		else if (randomRange >= 95 && randomRange <= 100)
			type = GameEnums.ObstacleType.bomb;

		//Debug.Log("Random Range :   " + randomRange + "   Type ;  " + type);
		return type;
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

	public void DestroyAllObstacle()
	{
		for (int i = 0; i < obstacleList.Count; i++)
		{
			Destroy(obstacleList[i].gameObject);
		}
		obstacleList.Clear();
	}

  
}
