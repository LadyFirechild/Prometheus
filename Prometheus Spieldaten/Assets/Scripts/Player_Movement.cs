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
        public PowerUp_Big PoUpBi;
        public PowerUp_Smaller PoUpSm;
        [SerializeField] private LayerMask whatIsGround;
        public Vector2 clampRbv;

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
            if (!PoUpBi.big && !PoUpSm.small)
            {
                rigidbody.velocity =new Vector2(-maxSpeed, rigidbody.velocity.y);
            }
            if (PoUpBi.big)
            {
                rigidbody.velocity =new Vector2(-maxSpeed * PoUpBi.bigMultiplier, rigidbody.velocity.y);
            }
            if (PoUpSm.small)
            {
                rigidbody.velocity =new Vector2(-maxSpeed * PoUpSm.smallMultiplier, rigidbody.velocity.y);
            }
        }

        public void MoveRight()
        {
            if (!PoUpBi.big && !PoUpSm.small)
            {
                rigidbody.velocity = new Vector2(maxSpeed, rigidbody.velocity.y);
            }
            if (PoUpBi.big)
            {
                rigidbody.velocity = new Vector2(maxSpeed * PoUpBi.bigMultiplier, rigidbody.velocity.y);
            }
            if (PoUpSm.small)
            {
                rigidbody.velocity = new Vector2(maxSpeed * PoUpSm.smallMultiplier, rigidbody.velocity.y);
            }
        }

        public void Jump()
        {
            if (grounded == true)
            {
                
                if (!PoUpBi.big && !PoUpSm.small)
                {
                    rigidbody.AddForce(new Vector2(0, jumpSpeed),ForceMode2D.Impulse);
                }
                if (PoUpBi.big)
                {
                    rigidbody.AddForce(new Vector2(0, jumpSpeed * PoUpBi.bigMultiplier),ForceMode2D.Impulse);
                }
                if (PoUpSm.small)
                {
                    rigidbody.AddForce(new Vector2(0, jumpSpeed * PoUpSm.smallMultiplier), ForceMode2D.Impulse);
                }
            }
        }

        public void OnTriggerEnter2D(Collider2D trigger)
        {
            if (trigger.gameObject.layer == whatIsGround && trigger.gameObject.tag != "PowerUp" && trigger.gameObject.tag != "Flame" && trigger.gameObject.tag != "Fire")
            {
                grounded = true;
            }
        }

        public void OnTriggerStay2D(Collider2D trigger)
        {
            if (trigger.gameObject.tag != "PowerUp" && trigger.gameObject.tag != "Fire" && trigger.gameObject.tag != "Flame")
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