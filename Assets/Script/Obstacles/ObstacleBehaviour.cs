using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleBehaviour : MonoBehaviour, IColliderEnter
{

    [SerializeField] private SpriteRenderer _mainImage;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Collider2D _collider;


    private Obstacle _obstacle;

    public void SetObstacle(Obstacle obstacle)
    {
        _obstacle = obstacle;
        _mainImage.sprite = obstacle.sprite;
        _mainImage.color = obstacle.color;
    }

    public void onCollide(Collision2D colidedObj2D)
    {
        _obstacle.obstacleEffct.DoCollisionAfterEffect();
        //PlaySound(_obstacle._collisionClip);
        //DestroyObstacle();
    }

    void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Stop();
        _audioSource.Play();
    }

    void DestroyObstacle()
    {
        _collider.enabled = false;
        _mainImage.enabled = false;

        Destroy(this.gameObject, .5f);
    }

    
}
