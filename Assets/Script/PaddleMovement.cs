using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    float paddleSpeed = 5.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            paddleMove(true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            paddleMove(false);
        }
    }


    public void paddleMove(bool isMoveUp)
    {
        Vector3 position = this.transform.position;
       
        if(isMoveUp)
            position.y = position.y + ( paddleSpeed*Time.deltaTime );
        else
            position.y = position.y - ( paddleSpeed * Time.deltaTime ); ;

        this.transform.position = position;
    }

}
