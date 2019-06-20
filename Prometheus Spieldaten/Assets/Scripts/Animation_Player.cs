using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

namespace Prometheus {
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
        }

        public void Update()
        {
            if (playerMovement.grounded)
            {
                walkAnim.animation.Stop("jumpAnim");
            }

            if (!walkAnim.animation.isPlaying && playerMovement.grounded && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                walkAnim.animation.Stop("jumpAnim");
                walkAnim.animation.Play("walkAnim");
                walkAnim.transform.localScale = new Vector3(Mathf.Abs(walkAnim.transform.localScale.x) * 1, walkAnim.transform.localScale.y, walkAnim.transform.localScale.z);
            }
            if (!walkAnim.animation.isPlaying && playerMovement.grounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {
                walkAnim.animation.Stop("jumpAnim");
                walkAnim.animation.Play("walkAnim");
                walkAnim.transform.localScale =  new Vector3(Mathf.Abs(walkAnim.transform.localScale.x) * - 1, walkAnim.transform.localScale.y, walkAnim.transform.localScale.z);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                //walkAnim.animation.Stop("walkAnim");
                walkAnim.animation.Reset();
            }
            if (playerMovement.grounded && ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))))
            {
                walkAnim.animation.Stop("walkAnim");
                walkAnim.animation.Play("jumpAnim",1);
                walkAnim.transform.localScale = new Vector3(Mathf.Abs(walkAnim.transform.localScale.x) * -1, walkAnim.transform.localScale.y, walkAnim.transform.localScale.z);
            }
            if (playerMovement.grounded && ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))))
            {
                walkAnim.animation.Stop("walkAnim");
                walkAnim.animation.Play("jumpAnim",1);
                walkAnim.transform.localScale = new Vector3(Mathf.Abs(walkAnim.transform.localScale.x) * 1, walkAnim.transform.localScale.y, walkAnim.transform.localScale.z);
            }
        }

    }
}

