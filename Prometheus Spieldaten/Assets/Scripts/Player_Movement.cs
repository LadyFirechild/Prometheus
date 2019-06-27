using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{
    public class Player_Movement : MonoBehaviour
    {
        public float runSpeed;
        public float jumpSpeed;
        public float climbSpeed;
        public new Rigidbody2D rigidbody;
        public bool grounded;
        public float maxSpeed = 50f;




        public void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxSpeed);
        }

        public void MoveLeft()
        {
            //rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * runSpeed, 0.0f));
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y) + new Vector2(-maxSpeed, rigidbody.velocity.y);
        }

        public void MoveRight()
        {
            // rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * runSpeed, 0.0f));
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y) + new Vector2(maxSpeed, rigidbody.velocity.y);
        }

        public void Jump()
        {
            if (grounded == true)
            {
                rigidbody.velocity = Vector2.up * jumpSpeed;
            }
        }

        public void OnTriggerEnter2D(Collider2D trigger)
        {
            grounded = true;
        }

        public void OnTriggerStay2D(Collider2D trigger)
        {
            grounded = true;
        }

        public void OnTriggerExit2D(Collider2D trigger)
        {
            grounded = false;
        }
    }
}