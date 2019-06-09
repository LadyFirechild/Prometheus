using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public bool wallTouch;

    public void Update()
    {
        if(wallTouch == true)
        {
            transform.rotation = new Quaternion(0,transform.rotation.y + 180, 0, 0);
        }
        else
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
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
