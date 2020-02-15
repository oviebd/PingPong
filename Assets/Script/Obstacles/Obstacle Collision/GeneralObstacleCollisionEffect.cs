using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObstacleCollisionEffect : ObstacleEffectBaseClass, IObstacleCollisionEffect
{
	[SerializeField] private List<AudioClip> _audioClipList;
	public void SetObstacleBehaviour(ObstacleBehaviour behaviour)
	{
		obstacleBehaviour = behaviour;
		_obstacle = behaviour.GetObstacleClass();
		AudioClip clip = SetAudioClip();
		if (clip != null && _obstacle != null)
			_obstacle.collisionClip = clip;
	}
	AudioClip SetAudioClip()
	{
		if (_audioClipList == null)
			return null;
		int index = Random.RandomRange(0,_audioClipList.Count);
		if (index < _audioClipList.Count)
			return _audioClipList[index];
		return null;
	}
    public void DoCollisionAfterEffect()
    {
		//PlaySound(_obstacle.collisionClip);
		//DestroyObject();
		OperateObstacleCollisionEffect();

	}
}
