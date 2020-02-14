using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffectBaseClass : MonoBehaviour
{
	public ObstacleBehaviour obstacleBehaviour;
	public Obstacle _obstacle;
	public float destroyTime = 2.0f;

	public void PlaySound(AudioClip clip)
	{
		obstacleBehaviour.GetAudioSource().clip = clip;
		obstacleBehaviour.GetAudioSource().Stop();
		obstacleBehaviour.GetAudioSource().Play();
	}

	public void DestroyObject()
	{
		obstacleBehaviour.getCollider().enabled = false;
		obstacleBehaviour.GetInnerSpriteRenderer().enabled = false;
		obstacleBehaviour.GetOuterSpriteRenderer().enabled = false;

		Destroy(obstacleBehaviour.gameObject, destroyTime);
	}

	public void UpdateScoreManagerData()
	{
		ScoreManager.instance.updateScoreManagerData(obstacleBehaviour.GetObstacleClass().value);
	}

	public void OperateObstacleCollisionEffect()
    {
		DestroyObject();
		PlaySound(_obstacle.collisionClip);
	
		UpdateScoreManagerData();
	}

}
