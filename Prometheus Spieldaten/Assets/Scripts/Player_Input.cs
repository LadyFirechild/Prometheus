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



    public void FixedUpdate()
    {
        bool right3 = Input.GetKey(right1);
        bool right4 = Input.GetKey(right2);

        if(right3 == true || right4 == true)
        {
            SendMessage("MoveRight", SendMessageOptions.DontRequireReceiver);
        }

        bool left3 = Input.GetKey(left1);
        bool left4 = Input.GetKey(left2);

        if (left3 == true || left4 == true)
        {
            SendMessage("MoveLeft", SendMessageOptions.DontRequireReceiver);
        }

        bool jumpUp3 = Input.GetKeyDown(jumpUp1);
        bool jumpUp4 = Input.GetKeyDown(jumpUp2);

        if (jumpUp3 == true ||  jumpUp4 == true)
        {
            SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
        }
    }
    
}
