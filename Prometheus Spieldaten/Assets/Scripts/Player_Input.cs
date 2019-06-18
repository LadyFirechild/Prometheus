using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{

    public KeyCode right1 = KeyCode.D;
    public KeyCode right2 = KeyCode.RightArrow;
    public KeyCode left1 = KeyCode.A;
    public KeyCode left2 = KeyCode.LeftArrow;
    public KeyCode jumpUp1 = KeyCode.W;
    public KeyCode jumpUp2 = KeyCode.UpArrow;
    public bool noLadder = true;
    public new Rigidbody rigidbody;
    public Player_Movement playerMovement;



    public void FixedUpdate()
    {
        bool right3 = Input.GetKey(right1);
        bool right4 = Input.GetKey(right2);
        bool left3 = Input.GetKey(left1);
        bool left4 = Input.GetKey(left2);
        if ((right3 == true || right4 == true) && (left3 == false && left4 == false))
        {
            SendMessage("MoveRight", SendMessageOptions.DontRequireReceiver);
            rigidbody.velocity += new Vector3(playerMovement.maxSpeed, rigidbody.velocity.y, 0);

        }




        if ((left3 == true || left4 == true) && (right3 == false && right4 == false))
        {

            SendMessage("MoveLeft", SendMessageOptions.DontRequireReceiver);

            rigidbody.velocity += new Vector3(-playerMovement.maxSpeed, rigidbody.velocity.y, 0);

        }



        if (((left3 == false && left4 == false) && (right3 == false && right4 == false)) && playerMovement.grounded == true)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints.None;
        }


        bool jumpUp3 = Input.GetKeyDown(jumpUp1);
        bool jumpUp4 = Input.GetKeyDown(jumpUp2);

        if (jumpUp3 == true || jumpUp4 == true)
        {
            SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
        }


    }
}
