using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableSlowDown : MonoBehaviour
{

    public new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
    }

}
