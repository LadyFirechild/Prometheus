using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public bool wallTouch = false;
    public float modForward;
    public float moveDirection;

    public void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        /*
        modForward = transform.rotation.y % 180;
        moveDirection = modForward % 2;

        if ((-.5f <= moveDirection && moveDirection <= 0) || moveDirection >0)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (-1f <= moveDirection && moveDirection <= -.5f)
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }*/




    }

    public void OnTriggerEnter(Collider other)
    {
        moveSpeed = -moveSpeed;

    }

}
