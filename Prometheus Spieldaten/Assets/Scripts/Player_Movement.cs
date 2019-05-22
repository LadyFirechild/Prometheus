using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public new Rigidbody rigidbody;
    

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveLeft()
    {
        transform.position = transform.position + new Vector3(-runSpeed * Time.deltaTime, 0, 0);
    }

    public void MoveRight()
    {
        transform.position = transform.position + new Vector3(+runSpeed * Time.deltaTime, 0, 0);
    }

    public void Jump()
    {
        rigidbody.AddForce(transform.up * jumpSpeed);
    }

}
