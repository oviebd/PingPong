﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleBehaviour : MonoBehaviour, IColliderEnter
{
    [SerializeField] private SpriteRenderer _mainImage;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Collider2D _collider;

	private Obstacle _obstacle;

	public delegate void OnBallCollideWithObstacle(int score);
	public static event OnBallCollideWithObstacle updateScoreManagerData;
	

    public void SetObstacle(Obstacle obstacle)
    {
        _obstacle = obstacle;
        _mainImage.sprite = obstacle.sprite;
        _mainImage.color = obstacle.color;
    }

    public void onCollide(Collision2D colidedObj2D)
    {
        _obstacle.obstacleEffct.DoCollisionAfterEffect(this,_obstacle);
		//PlaySound(_obstacle._collisionClip);
		//DestroyObstacle();
		UpdateScoreManagerData();
    }

	public void UpdateScoreManagerData()
	{
		updateScoreManagerData(_obstacle.value);
	}

    public AudioSource GetAudioSource()
    {
        return _audioSource;
    }
    public SpriteRenderer GetSpriteRenderer()
    {
        return _mainImage;
    }
    public Collider2D getCollider()
    {
        return _collider;
    }

    
}