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

    public delegate void Dead();
    public Dead onDeath;

    bool canMove = true;

    // Use this for initialization
    void Awake()
    {
        //Wisps rigidbody
        Wisp = GetComponent<Rigidbody>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x < Screen.width * 0.5f)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
        }
        //Clamp for Max Velocity
        Wisp.velocity = new Vector3(Mathf.Clamp(Wisp.velocity.x, -maxSpeed, maxSpeed), Wisp.velocity.y);
    }

    public void MoveLeft()
    {
        //Add Force Left
        Wisp.AddForce(Vector3.left * speed);
    }

    public void MoveRight()
    {
        //Add Force Right
        Wisp.AddForce(Vector3.right * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Traps"))
        {
            if (onDeath != null)
            {
                canMove = false;
                onDeath();
            }
        }
    }
}