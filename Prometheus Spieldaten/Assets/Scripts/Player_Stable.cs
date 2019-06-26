using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stable : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
