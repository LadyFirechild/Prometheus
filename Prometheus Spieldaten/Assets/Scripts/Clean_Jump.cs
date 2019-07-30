using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean_Jump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float exponent;
    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rigidbody.velocity.y < 0)
        {         
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (Mathf.Pow(fallMultiplier, exponent) - 1 ) * Time.deltaTime;
        }
    }
}
