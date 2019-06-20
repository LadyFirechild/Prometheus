using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

namespace Prometheus
{
    public class Animation_Player : MonoBehaviour



    {

        public Player_Movement playerMovement;
        [SerializeField] UnityArmatureComponent walkAnim;


        // Start is called before the first frame update


        // Update is called once per frame

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

            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                walkAnim.transform.localScale = new Vector3(Mathf.Abs(walkAnim.transform.localScale.x) * 1, walkAnim.transform.localScale.y, walkAnim.transform.localScale.z);
                if (!walkAnim.animation.isPlaying && playerMovement.grounded && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
                {

                    walkAnim.animation.Stop("jumpAnim");
                    walkAnim.animation.Play("walkAnim");
                }

            }

            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {
                walkAnim.transform.localScale = new Vector3(Mathf.Abs(walkAnim.transform.localScale.x) * -1, walkAnim.transform.localScale.y, walkAnim.transform.localScale.z);
                if (!walkAnim.animation.isPlaying && playerMovement.grounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
                {
                    walkAnim.animation.Stop("jumpAnim");
                    walkAnim.animation.Play("walkAnim");
                }

            }

            if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)))
            {
                walkAnim.animation.Reset();
            }

            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            {
                walkAnim.transform.localScale = new Vector3(Mathf.Abs(walkAnim.transform.localScale.x) * -1, walkAnim.transform.localScale.y, walkAnim.transform.localScale.z);
            }

            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
            {
                walkAnim.transform.localScale = new Vector3(Mathf.Abs(walkAnim.transform.localScale.x) * 1, walkAnim.transform.localScale.y, walkAnim.transform.localScale.z);
            }

            if (playerMovement.grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                walkAnim.animation.Stop("walkAnim");
                walkAnim.animation.Play("jumpAnim", 1);
            }


        }

        public void OnCollisionEnter(Collision coll)
        {
            if (coll.gameObject.tag == "Moveable" && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
            {
                walkAnim.animation.Play("holdAnim", 1);
            }

            if (coll.gameObject.tag == "Moveable" && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
            {
                walkAnim.animation.Play("pushAnim", 1);
            }

        }
        public void OnCollisionStay(Collision coll)
        {
            if (coll.gameObject.tag == "Moveable" && !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
            {
                walkAnim.animation.Play("holdAnim", 1);
            }
            if (coll.gameObject.tag == "Moveable" && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
            {
                walkAnim.animation.Play("pushAnim", 1);
            }
        }

        public void OnCollisionExit(Collision coll)
        {
            if (coll.gameObject.tag == "Moveable")
            {
                walkAnim.animation.Stop("holdAnim");
                walkAnim.animation.Stop("pushAnim");
            }
        }
    }
}

