using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBaseClass : MonoBehaviour
{
    public GameEnums.ObstacleType obstacleType = GameEnums.ObstacleType.type1;
    [SerializeField] private Color _outerImageColor;
    [SerializeField] private Sprite _outerImageSprite;
    [SerializeField] private Color _innerImageColor;
    [SerializeField] private Sprite _innerImageSprite;
    [SerializeField] private AudioClip _collisionClip;
    [SerializeField] private AudioClip _destructionClip;
    [SerializeField] private int _value = 5;


    [SerializeField] private SpriteRenderer _innerImageRenderer;
    [SerializeField] private SpriteRenderer _outerImageRenderer;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Collider2D _collider;

    private Obstacle _obstacle;

    public void InitializeObstacle()
    {
        _obstacle = new Obstacle();

        SetObstacleClass();
        SetObstacleGrapgics();
    }

    void SetObstacleClass()
    {
        if (_outerImageColor != null) _obstacle.outerImageColor   = _outerImageColor;
        if (_outerImageSprite != null) _obstacle.outerImageSprite = _outerImageSprite;
        if (_innerImageColor != null) _obstacle.innerImageColor   = _innerImageColor;
        if (_innerImageSprite != null) _obstacle.innerImageSprite = _innerImageSprite;

        if (_collisionClip != null) _obstacle.collisionClip     = _collisionClip;
        if (_destructionClip != null) _obstacle.destructionClip = _destructionClip;

        _obstacle.value = _value;
        _obstacle.obstacleType = obstacleType;
    }

    void SetObstacleGrapgics()
    {
        if (_innerImageColor != null) _innerImageRenderer.color   = _innerImageColor;
        if (_innerImageSprite != null) _innerImageRenderer.sprite = _innerImageSprite;

        if (_outerImageColor != null)  _outerImageRenderer.color = _outerImageColor;
        if (_outerImageSprite != null) _outerImageRenderer.sprite = _outerImageSprite;

    }

    public Obstacle GetObstacleClass()
    {
        return _obstacle;
    }

    public AudioSource GetAudioSource()
    {
        return _audioSource;
    }
    public SpriteRenderer GetSpriteRenderer()
    {
        return _innerImageRenderer;
    }
    public Collider2D getCollider()
    {
        return _collider;
    }


}
