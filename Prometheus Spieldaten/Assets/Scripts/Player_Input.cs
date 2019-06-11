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
    public KeyCode duck1 = KeyCode.S;
    public KeyCode duck2 = KeyCode.DownArrow;
    public bool noLadder = true;



    public void FixedUpdate()
    {
        bool right3 = Input.GetKey(right1);
        bool right4 = Input.GetKey(right2);

        if (right3 == true || right4 == true)
        {
            SendMessage("MoveRight", SendMessageOptions.DontRequireReceiver);
        }

        bool left3 = Input.GetKey(left1);
        bool left4 = Input.GetKey(left2);

        if (left3 == true || left4 == true)
        {
            SendMessage("MoveLeft", SendMessageOptions.DontRequireReceiver);
        }

        bool jumpUp3 = Input.GetKey(jumpUp1);
        bool jumpUp4 = Input.GetKey(jumpUp2);

        if (jumpUp3 == true || jumpUp4 == true)
        {
            if (noLadder == true)
            {
                jumpUp3 = Input.GetKeyDown(jumpUp1);
                jumpUp4 = Input.GetKeyDown(jumpUp2);
                SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
            }
            if (noLadder == false)
            {
                SendMessage("Climb", SendMessageOptions.DontRequireReceiver);
            }
        }

        bool duck3 = Input.GetKey(duck1);
        bool duck4 = Input.GetKey(duck2);


        if (duck3 == true || duck4 == true)
        {
            if (noLadder == false)
            {
                SendMessage("Duck", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    public void OnTriggerEnter(Collider trigger)
    {

        if (trigger.gameObject.tag == "Ladder")
        {
            noLadder = false;
        }
        if (trigger.gameObject.tag != "Ladder")
        {
            noLadder = true;
        }
    }

    public void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.tag == "Ladder")
        {
            noLadder = false;
        }
        if (trigger.gameObject.tag != "Ladder")
        {
            noLadder = true;
        }
    }

    public void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "Ladder")
        {
            noLadder = true;
        }

    }
}
