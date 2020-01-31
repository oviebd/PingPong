using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBaseClass : MonoBehaviour
{
    public GameEnums.ballType ballType;

    public BallMovement _ballMovement;
    public Rigidbody2D _rb;

    [SerializeField] private Vector2 _initialVelocity = Vector2.zero;
    [SerializeField] private Vector2 _maximumVelocity = new Vector2(50f,50f);
    [SerializeField] private Color _color = Color.white;

    Ball _ball;

    public void InitializeBall()
    {
        SetBall();
    }

    private void SetBall()
    {
        _ball = new Ball();

        _ball.initialVelocity = _initialVelocity;
        _ball.maximumVelocity = _maximumVelocity;
        _ball.color = _color;
    }

    void SetBallGraphics()
    {
    }

    public Ball GetBall()
    {
        return this._ball;
    }
    public void UpdateBall(Ball ball)
    {
       this._ball = ball;
    }
    public Rigidbody2D GetRb()
    {
        return _rb;
    }
    public BallMovement GetBallMovement()
    {
        return _ballMovement;
    }
}
