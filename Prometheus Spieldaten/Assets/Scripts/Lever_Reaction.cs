using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Reaction : MonoBehaviour
{
    public GameObject Door;
    public BoxCollider2D BC;

    public void Start()
    {
        BC = GetComponent<BoxCollider2D>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Moveable")
        {
            BC.isTrigger = true;
            Door.gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Moveable")
        {
            BC.isTrigger = true;
            Door.gameObject.SetActive(false);
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Moveable")
        {
            BC.isTrigger = false;
            Door.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Player")
        {
            Door.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            BC.isTrigger = false;
            Door.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BC.isTrigger = false;
            Door.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            BC.isTrigger = true;
            //Door.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Moveable")
        {
            Door.gameObject.SetActive(true);
        }
    }
}
