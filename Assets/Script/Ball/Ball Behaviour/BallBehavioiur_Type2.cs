using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavioiur_Type2 : MonoBehaviour,IBallBehaviour
{
    private Vector2 initialVelocity =new Vector2(8,-15);
    private Rigidbody2D _rb;

    BallBehaviour _ballBehaviour;

    public void SetUp(BallBehaviour behaviour)
    {
        this._ballBehaviour = behaviour;
        _rb = _ballBehaviour.GetRb();
        SetInitialValocity();
    }

    IEnumerator SetInitialValocity()
    {
        yield return new WaitForSeconds(.05f);
        initialVelocity = this._ballBehaviour.GetBallMovement().GetInitialVelocity();
    }

    public void OperationAfterCollision(Collision2D colidedObj2D)
    {
        //GoPreviousDirection();
        if (colidedObj2D.gameObject.tag == GameEnums.Tag.obstacle.ToString())
            GoPreviousDirection();
        if (colidedObj2D.gameObject.tag == GameEnums.Tag.paddle.ToString() ||
                           colidedObj2D.gameObject.tag == GameEnums.Tag.wall.ToString())
            SetInitialVelocity();
    }

    void SetInitialVelocity()
    {
        if (_rb != null)
        {
            initialVelocity = _rb.velocity;
        }
        //Debug.Log("init vel : " + initialVelocity);
    }
    void GoPreviousDirection()
    {
       // Debug.Log("Go prev direction .... befoere if initial vel : " + initialVelocity);
        if (_rb != null)
        {
          //  Debug.Log("Go prev direction .... in if ");
            _rb.velocity = Vector2.zero;
            _rb.velocity = initialVelocity;
            //_rb.AddForce (initialVelocity);
        }
    }


}
