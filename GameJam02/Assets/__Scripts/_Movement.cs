using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Movement : MonoBehaviour
{
    //Wisp RigidBody
    Rigidbody Wisp;
    //Speed
    public float speed;
    //Clamped Speed
    public float maxSpeed;


    // Use this for initialization
    void Start()
    {
        //Wisps rigidbody
        Wisp = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            MoveRight();
        }

        //Clamp for Max Velocity
        Wisp.velocity = new Vector3(Mathf.Clamp(Wisp.velocity.x, -maxSpeed, maxSpeed), Wisp.velocity.y);
    }
    
    public void MoveLeft()
    {
        //Add Force Left
        Wisp.AddForce(-Wisp.transform.right* speed);
    }

    public void MoveRight()
    {
        //Add Force Right
        Debug.Log("Im WORKING");
        Wisp.AddForce(Wisp.transform.right* speed);
    }

    public void MoveUp()
    {
        Wisp.AddForce(Wisp.transform.up* speed);
    }
}