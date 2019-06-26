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
        Vector2 rbv;




        public void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxSpeed);
            rbv = rigidbody.velocity;
            if (rbv.y <= 0)
            {
                rigidbody.velocity = new Vector2(rbv.x, rbv.y * 1.2f);
            }
        }

        public void MoveLeft()
        {
            rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * runSpeed, 0.0f));
        }

        public void MoveRight()
        {
            rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * runSpeed, 0.0f));
        }

        public void Jump()
        {
            if (grounded == true)
            {
                rigidbody.AddForce(Vector2.up * jumpSpeed);
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