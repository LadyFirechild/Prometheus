using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

namespace Prometheus
{
    public class Animation_Player : MonoBehaviour
    {

        public Player_Movement playerMovement;
        public Player_Input playerInput;
        [SerializeField] UnityArmatureComponent walkAnim;
        public Vector2 velocity;
        public bool Idle;
        public bool AirBorne;
        public bool Push;


        public void Awake()
        {
            UnityArmatureComponent walkAnim = GetComponent<UnityArmatureComponent>();
        }

        public void Start()
        {
            walkAnim.animation.Stop("walkAnim");
            walkAnim.animation.Stop("jumpAnim");
            walkAnim.animation.Stop("fallAnim");
            walkAnim.animation.Stop("pushAnim");
            walkAnim.animation.Stop("idleAnim");
        }

        public void FixedUpdate()
        {
            velocity = playerInput.rigidbody.velocity;

            if (playerInput.right)
            {
                walkAnim.transform.localScale = new Vector2(Mathf.Abs(walkAnim.transform.localScale.x) * 1, walkAnim.transform.localScale.y);
                if (!walkAnim.animation.isPlaying && playerMovement.grounded && playerInput.right && Idle == false)
                {
                    walkAnim.animation.Stop("jumpAnim");
                    walkAnim.animation.Stop("idleAnim");
                    walkAnim.animation.Play("walkAnim");
                }
            }

            if (playerInput.left)
            {
                walkAnim.transform.localScale = new Vector2(Mathf.Abs(walkAnim.transform.localScale.x) * -1, walkAnim.transform.localScale.y);
                if (!walkAnim.animation.isPlaying && playerMovement.grounded && playerInput.left && Idle == false)
                {
                    walkAnim.animation.Stop("jumpAnim");
                    walkAnim.animation.Stop("idleAnim");
                    walkAnim.animation.Play("walkAnim");
                }
            }

            if (!playerInput.right && !playerInput.left && !playerInput.jump && playerMovement.grounded)
            {
                Idle = true;
                walkAnim.animation.Stop("walkAnim");
                Debug.Log("Idle on");
            }
            else if (playerInput.right || playerInput.left || playerInput.jump)
            {
                Idle = false;
                Debug.Log("Idle off");
            }

            if (playerInput.left && playerInput.jump)
            {
                walkAnim.transform.localScale = new Vector2(Mathf.Abs(walkAnim.transform.localScale.x) * -1, walkAnim.transform.localScale.y);
            }

            if (playerInput.right && playerInput.jump)
            {
                walkAnim.transform.localScale = new Vector2(Mathf.Abs(walkAnim.transform.localScale.x) * 1, walkAnim.transform.localScale.y);
            }

            if (velocity.y >= 0)
            {
                if (playerInput.jump && playerMovement.grounded)
                {
                    walkAnim.animation.Stop("walkAnim");
                    walkAnim.animation.Play("jumpAnim", 1);
                    AirBorne = true;
                }
            }

            if (velocity.y < 0 && AirBorne == true)
            {
                walkAnim.animation.Stop("jumpAnim");
                walkAnim.animation.Play("fallAnim", 1);
                AirBorne = false;
            }



            if (Idle == true)
            {
                if (!walkAnim.animation.isPlaying)
                {
                    walkAnim.animation.Play("idleAnim");
                }
            }

            if (Idle == false)
            {
                walkAnim.animation.Stop("idleAnim");
            }

            if (playerMovement.grounded)
            {
                walkAnim.animation.Stop("fallAnim");
            }



            if (Push == true)
            {
                walkAnim.animation.Stop("walkAnim");
                walkAnim.animation.Stop("jumpAnim");
                walkAnim.animation.Stop("fallAnim");
                if (!walkAnim.animation.isPlaying)
                {
                    walkAnim.animation.Play("pushAnim");
                }
            }

            if (Push == false)
            {
                walkAnim.animation.Stop("pushAnim");
            }
        }

        public void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Moveable" && (playerInput.left || playerInput.right))
            {
                Push = true;
            }
            else
            {
                Push = false;
            }

        }
        public void OnCollisionStay2D(Collision2D coll)
        {

            if (coll.gameObject.tag == "Moveable" && (playerInput.left || playerInput.right))
            {
                Push = true;
            }
            else
            {
                Push = false;
            }
        }

        public void OnCollisionExit2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Moveable")
            {
                Push = false;
            }
        }
    }
}