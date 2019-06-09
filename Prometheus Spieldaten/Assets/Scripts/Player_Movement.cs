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
    public SpriteRenderer spriteRenderer;
    public bool flipX = false;


    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
    }

    public void MoveLeft()
    {
        spriteRenderer.flipX = true;
        movingLeft = new Vector3(-runSpeed * Time.deltaTime, 0, 0);
        transform.position = transform.position + movingLeft;
    }

    public void MoveRight()
    {
        spriteRenderer.flipX = false;
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
        rigidbody.isKinematic = true;

        climbing = new Vector3(0, -climbSpeed * Time.deltaTime, 0);
        transform.position = transform.position + climbing;
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
