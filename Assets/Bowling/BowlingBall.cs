using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float forwardForce;
    public float leftBorder;
    public float rightBorder;
    public float moveIncrement;
    public Rigidbody rig;
    public float speed;
    private bool moveL = false;
    private bool startBowl = false;
    
    private void Update() {

        
        if (transform.position.x < leftBorder && moveL)
        {
            speed = speed * -1;
            moveL = false;              
        }else if(transform.position.x > rightBorder && !moveL)
        {
            speed = speed * -1;
            moveL = true;            
        }

        move(speed);
    }

    public void Bowl()
    {        
        rig.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
        startBowl = true;
    }

    void move(float speed)
    {
        if (!startBowl)
        {
            transform.position += new Vector3(speed * Time.deltaTime,0,0);            
        }
    }    
}
