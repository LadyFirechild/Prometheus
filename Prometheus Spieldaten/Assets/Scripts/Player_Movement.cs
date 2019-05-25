using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float climbSpeed;
    public new Rigidbody rigidbody;
    public Vector2 scale;
    Vector3 movingRight;
    Vector3 movingLeft;
    Vector3 climbing;
    public bool grounded;
    public bool noLadder;


    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    public void FixedUpdate()
    {
    }

    public void MoveLeft()
    {

        movingLeft = new Vector3(-runSpeed * Time.deltaTime, 0, 0);
        transform.position = transform.position + movingLeft;
    }

    public void MoveRight()
    {
        movingRight = new Vector3(runSpeed * Time.deltaTime, 0, 0);
        transform.position = transform.position + movingRight;
    }

    public void Jump()
    {
        if (grounded == true && noLadder == true)
        {
            rigidbody.AddForce(transform.up * jumpSpeed);
        }
    }

    public void Climb()
    {
        rigidbody.isKinematic = true;
            
        climbing = new Vector3(0, climbSpeed * Time.deltaTime, 0);
        transform.position = transform.position + climbing;
        
    }
    public void Duck()
    {
        scale = gameObject.GetComponent<Collider>().transform.localScale;
        scale.y *= .5f;
    }

    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag != "Ladder")
        {
            grounded = true;
            noLadder = true;
        }
        if (trigger.gameObject.tag == "Ladder")
        {
            noLadder = false;
        }
    }

    public void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag != "Ladder")
        {
            grounded = false;
        }
        if (trigger.gameObject.tag == "Ladder")
        {
            noLadder = true;
            rigidbody.isKinematic = false;
        }
    }
}
