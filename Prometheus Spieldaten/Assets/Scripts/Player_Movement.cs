using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{
    public class Player_Movement : MonoBehaviour
    {
        public float jumpSpeed;
        public new Rigidbody2D rigidbody;
        public bool grounded;
        public float maxSpeed = 50f;
        [SerializeField] private LayerMask whatIsGround;
        public Vector2 clampRbv;
        public PowerUp_Size pUSize;

        public void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            clampRbv = rigidbody.velocity;
            clampRbv.x = Mathf.Clamp(clampRbv.x, -maxSpeed, maxSpeed);
            rigidbody.velocity = clampRbv;
        }

        public void MoveLeft()
        {
            if (pUSize.normal)
            {
                rigidbody.velocity = new Vector2(-maxSpeed, rigidbody.velocity.y);
            }
            if (pUSize.big)
            {
                rigidbody.velocity = new Vector2(-maxSpeed * pUSize.SizeNormalBig, rigidbody.velocity.y);
            }
            if (pUSize.small)
            {
                rigidbody.velocity = new Vector2(-maxSpeed * pUSize.SizeNormalSmall, rigidbody.velocity.y);
            }
        }

        public void MoveRight()
        {
            if (pUSize.normal)
            {
                rigidbody.velocity = new Vector2(maxSpeed, rigidbody.velocity.y);
            }
            if (pUSize.big)
            {
                rigidbody.velocity = new Vector2(maxSpeed * pUSize.SizeNormalBig, rigidbody.velocity.y);
            }
            if (pUSize.small)
            {
                rigidbody.velocity = new Vector2(maxSpeed * pUSize.SizeNormalSmall, rigidbody.velocity.y);
            }
        }

        public void Jump()
        {
            if (grounded == true)
            {
                if (pUSize.normal)
                {
                    rigidbody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                }
                if (pUSize.small)
                {
                    rigidbody.AddForce(new Vector2(0, jumpSpeed * pUSize.SizeNormalSmall), ForceMode2D.Impulse);
                }
                if (pUSize.big)
                {
                    rigidbody.AddForce(new Vector2(0, jumpSpeed * pUSize.SizeNormalBig), ForceMode2D.Impulse);
                }

            }
        }

        public void OnTriggerEnter2D(Collider2D trigger)
        {
            if (trigger.gameObject.layer == whatIsGround && trigger.gameObject.tag != "NormalPU" && trigger.gameObject.tag != "BigPU" && trigger.gameObject.tag != "SmallPU" && trigger.gameObject.tag != "Flame" && trigger.gameObject.tag != "Fire" && trigger.gameObject.tag != "BigChalice")
            {
                grounded = true;
            }
        }

        public void OnTriggerStay2D(Collider2D trigger)
        {
            if (trigger.gameObject.tag != "NormalPU" && trigger.gameObject.tag != "BigPU" && trigger.gameObject.tag != "SmallPU" && trigger.gameObject.tag != "Fire" && trigger.gameObject.tag != "Flame" && trigger.gameObject.tag != "BigChalice")
            {
                grounded = true;
            }
        }

        public void OnTriggerExit2D(Collider2D trigger)
        {
            grounded = false;
        }

    }
}