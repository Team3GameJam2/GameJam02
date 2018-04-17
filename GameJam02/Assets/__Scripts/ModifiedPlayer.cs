using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedPlayer : MonoBehaviour
{
    //Wisp RigidBody
    Rigidbody Wisp;
    //Speed
    public float speed;
    //Clamped Speed
    public float maxSpeed;

    bool moveRight, moveLeft;

    public GameObject counter;
    public bool alive = false;

    // Use this for initialization
    void Awake()
    {
        //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        //Wisps rigidbody
        Wisp = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            MoveRight();
        }

        if (moveLeft)
        {
            MoveLeft();
        }

        if (!alive)
        {
            counter.GetComponent<UIScore>().OnEndGame();
            PausePlayer();
        }

        //Clamp for Max Velocity
        Wisp.velocity = new Vector3(Mathf.Clamp(Wisp.velocity.x, -maxSpeed, maxSpeed), Wisp.velocity.y);
    }

    public void MoveLeft()
    {
        //Add Force Left
        Wisp.AddForce(-Wisp.transform.right * speed);
    }

    public void MoveRight()
    {
        //Add Force Right
        Wisp.AddForce(Wisp.transform.right * speed);
    }

    public void SetMoveRight(bool move)
    {
        moveRight = move;
    }

    public void SetMoveLeft(bool move)
    {
        moveLeft = move;
    }

    public void MoveUp()
    {
        Wisp.AddForce(Wisp.transform.up * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            alive = false;
            counter.GetComponent<UIScore>().OnEndGame();
        }
    }

    public void PausePlayer()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    public void unfreezePlayer()
    {
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        playerAlive();
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    public void playerAlive()
    {
        alive = true;
    }
}