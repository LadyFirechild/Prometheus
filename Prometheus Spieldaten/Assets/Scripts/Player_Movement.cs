using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

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
    SpriteRenderer spriteRenderer;
    public bool flipX = false;
    public float maxSpeed = 50f;
    Vector3 rbv;
    public Armature walking;





    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
        Vector3 rbv = rigidbody.velocity;
        if (rbv.y <= 0)
        {
            rigidbody.velocity = new Vector3(rbv.x,rbv.y * 1.2f,rbv.z);
        }
    }

    public void MoveLeft()
    {
        spriteRenderer.flipX = true;
        rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * runSpeed, 0.0f, 0.0f));

    }

    public void MoveRight()
    {
        spriteRenderer.flipX = false;
        rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal") * runSpeed, 0.0f, 0.0f));
        
    }

    public void Jump()
    {
        if (grounded == true && noLadder == true)
        {
            rigidbody.AddForce(transform.up * jumpSpeed,ForceMode.VelocityChange);

        }
    }

    public void Climb()
    {
        rigidbody.isKinematic = true;

        climbing = new Vector3(0, climbSpeed * Time.deltaTime, 0);
        transform.position = transform.position + climbing;

    }

    public void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag != "Ladder" && trigger.gameObject.tag != "AI" && trigger.gameObject.tag != "AI_SightRange")
        {
            grounded = true;
            noLadder = true;
        }
        if (trigger.gameObject.tag == "Ladder")
        {
            noLadder = false;
        }
    }

    public void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.tag != "Ladder" && trigger.gameObject.tag != "AI" && trigger.gameObject.tag != "AI_SightRange")
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
        if (trigger.gameObject.tag != "Ladder" && trigger.gameObject.tag != "AI" && trigger.gameObject.tag != "AI_SightRange")
        {
            grounded = false;
        }
        if (trigger.gameObject.tag == "Ladder")
        {
            noLadder = true;
            rigidbody.isKinematic = false;
        }
    }

    //public void IgnoreCollision(Collider coll1, Collider coll2, bool ignore = true)
    //{
    //    if (coll1.tag == "Player" && coll2.tag == "Wall")
    //    {
    //        Physics.IgnoreCollision(coll1, coll2);

    //    }
    //}


}
