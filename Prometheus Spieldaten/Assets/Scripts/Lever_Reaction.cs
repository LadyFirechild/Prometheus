using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Reaction : MonoBehaviour
{
    public GameObject Door;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject)
        {
            Door.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            Door.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject)
        {
            Door.gameObject.SetActive(true);
        }
    }
}
