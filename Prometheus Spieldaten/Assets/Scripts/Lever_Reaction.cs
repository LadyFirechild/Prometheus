using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Reaction : MonoBehaviour
{
    public GameObject Door;
    public BoxCollider2D BoxColl;
    public Animator doorOpen;
    public bool isOpen;


    void Start()
    {
        BoxColl = GetComponent<BoxCollider2D>();
        doorOpen = Door.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           // if (doorOpen != null)
           //     doorOpen = true;
            Door.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Moveable")
        {
            Physics2D.IgnoreCollision(collision.collider, BoxColl);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Door.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Moveable")
        {
            Physics2D.IgnoreCollision(collision.collider, BoxColl);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Moveable")
        {

            Door.gameObject.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Moveable")
        {

            Door.gameObject.SetActive(false);
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Moveable")
        {

            Door.gameObject.SetActive(false);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Moveable")
        {

            Door.gameObject.SetActive(true);
        }
    }
}
