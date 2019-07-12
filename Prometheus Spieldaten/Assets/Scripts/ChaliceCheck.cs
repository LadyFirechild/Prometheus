using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaliceCheck : MonoBehaviour
{
    public bool bigChalice = false;
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            bigChalice = true;
        }
    }
}
