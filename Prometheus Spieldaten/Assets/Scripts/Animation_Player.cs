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


        public void Awake()
        {
            UnityArmatureComponent walkAnim = GetComponent<UnityArmatureComponent>();
        }

        public void Start()
        {
            walkAnim.animation.Stop("walkAnim");
            walkAnim.animation.Stop("jumpAnim");
            walkAnim.animation.Stop("holdAnim");
            walkAnim.animation.Stop("pushAnim");
        }

        public void Update()
        {

            if (playerInput.right)
            {
                walkAnim.transform.localScale = new Vector2(Mathf.Abs(walkAnim.transform.localScale.x) * 1, walkAnim.transform.localScale.y);
                if (!walkAnim.animation.isPlaying && playerMovement.grounded && playerInput.right)
                {
                    walkAnim.animation.Stop("jumpAnim");
                    walkAnim.animation.Play("walkAnim");
                }

            }

            if (playerInput.left)
            {
                walkAnim.transform.localScale = new Vector2(Mathf.Abs(walkAnim.transform.localScale.x) * -1, walkAnim.transform.localScale.y);
                if (!walkAnim.animation.isPlaying && playerMovement.grounded && playerInput.left)
                {
                    walkAnim.animation.Stop("jumpAnim");
                    walkAnim.animation.Play("walkAnim");
                }

            }

            if (!playerInput.right && !playerInput.left)
            {
                walkAnim.animation.Stop();
            }

            if (playerInput.left && playerInput.jump)
            {
                walkAnim.transform.localScale = new Vector2(Mathf.Abs(walkAnim.transform.localScale.x) * -1, walkAnim.transform.localScale.y);
            }

            if (playerInput.right && playerInput.jump)
            {
                walkAnim.transform.localScale = new Vector2(Mathf.Abs(walkAnim.transform.localScale.x) * 1, walkAnim.transform.localScale.y);
            }

            if (playerInput.jump && playerMovement.grounded)
            {
                walkAnim.animation.Play("jumpAnim", 1);
            }


        }

        public void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Moveable" && !(playerInput.left || playerInput.right))
            {
                walkAnim.animation.Play("holdAnim", 1);
            }

            if (coll.gameObject.tag == "Moveable" && (playerInput.left || playerInput.right))
            {
                walkAnim.animation.Play("pushAnim", 1);
            }

        }
        public void OnCollisionStay2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Moveable" && !(playerInput.left || playerInput.right))
            {
                walkAnim.animation.Play("holdAnim", 1);
            }
            if (coll.gameObject.tag == "Moveable" && (playerInput.left || playerInput.right))
            {
                walkAnim.animation.Play("pushAnim", 1);
            }
        }

        public void OnCollisionExit2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Moveable")
            {
                walkAnim.animation.Stop("holdAnim");
                walkAnim.animation.Stop("pushAnim");
            }
        }
    }
}

