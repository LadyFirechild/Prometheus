using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public bool wallTouch;
    public float modForward;
    public float moveDirection;

    public void Update()
    {
        modForward = transform.rotation.y % 180;
        moveDirection = modForward % 2;

        if (.5f >= moveDirection && moveDirection >= 0)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (1 >= moveDirection && moveDirection >= .5f )
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if (wallTouch == true && moveDirection == 0)
        {
            transform.Rotate(0, 180 , 0, 0);
        }
        if (wallTouch == true && moveDirection != 0)
        {
            transform.Rotate(0, -180, 0, 0);
        }



    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            wallTouch = true;
        }
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            wallTouch = false;
        }
    }



    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            wallTouch = false;
        }
    }
}
