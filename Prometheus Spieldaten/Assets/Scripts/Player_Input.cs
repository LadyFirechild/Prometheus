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
        public new Rigidbody2D rigidbody;
        public Player_Movement playerMovement;
        public bool jump;


        public void FixedUpdate()
        {
            right = Input.GetKey(right1) || Input.GetKey(right2);
            left = Input.GetKey(left1) || Input.GetKey(left2);
            if (right)
            {
                SendMessage("MoveRight", SendMessageOptions.DontRequireReceiver);        

            }
            else if (left)
            {
                SendMessage("MoveLeft", SendMessageOptions.DontRequireReceiver);
                
            }



            if (!left && !right)
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.constraints = RigidbodyConstraints2D.None;
            }

        }
        public void Update()
        {
            
        jump = Input.GetKeyDown(jumpUp1) || Input.GetKeyDown(jumpUp2);

            if (jump)
            {
                SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
            }


        }
    }
}