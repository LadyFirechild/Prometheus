using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Prometheus
{
    public class Player_Input : MonoBehaviour
    {

        public KeyCode right1 = KeyCode.D;
        public KeyCode right2 = KeyCode.RightArrow;
        public KeyCode left1 = KeyCode.A;
        public KeyCode left2 = KeyCode.LeftArrow;
        public KeyCode jumpUp1 = KeyCode.W;
        public KeyCode jumpUp2 = KeyCode.UpArrow;
        public bool right;
        public bool left;
        public new Rigidbody rigidbody;
        public Player_Movement playerMovement;



        public void FixedUpdate()
        {
            right = Input.GetKey(right1) || Input.GetKey(right2);
            left = Input.GetKey(left1) || Input.GetKey(left2);
            if (right == true)
            {
                SendMessage("MoveRight", SendMessageOptions.DontRequireReceiver);
                rigidbody.velocity += new Vector3(playerMovement.maxSpeed, rigidbody.velocity.y, 0);

            }
            else if (left == true)
            {

                SendMessage("MoveLeft", SendMessageOptions.DontRequireReceiver);

                rigidbody.velocity += new Vector3(-playerMovement.maxSpeed, rigidbody.velocity.y, 0);

            }



            if (left == false && right == false && playerMovement.grounded == true)
            {
                rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
                rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
            }
            else
            {
                rigidbody.constraints = RigidbodyConstraints.None;
            }


            bool jumpUp = Input.GetKeyDown(jumpUp1) || Input.GetKeyDown(jumpUp2);

            if (jumpUp == true)
            {
                SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
            }


        }
    }
}