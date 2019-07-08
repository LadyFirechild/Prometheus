using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean_Jump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rigidbody.velocity.y < 0)
        {
            fallMultiplier = Mathf.Pow(fallMultiplier, 1.0045f);
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1 ) * Time.deltaTime;
        }
    }
}
