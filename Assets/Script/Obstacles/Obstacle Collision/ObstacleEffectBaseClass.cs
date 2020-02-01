using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffectBaseClass : MonoBehaviour
{
	public ObstacleBehaviour obstacleBehaviour;
	public Obstacle _obstacle;
	public float destroyTime = .5f;

	public void PlaySound(AudioClip clip)
	{
		obstacleBehaviour.GetAudioSource().clip = clip;
		obstacleBehaviour.GetAudioSource().Stop();
		obstacleBehaviour.GetAudioSource().Play();
	}

	public void DestroyObject()
	{
		obstacleBehaviour.getCollider().enabled = false;
		obstacleBehaviour.GetSpriteRenderer().enabled = false;

		Destroy(obstacleBehaviour.gameObject, destroyTime);
	}

}
