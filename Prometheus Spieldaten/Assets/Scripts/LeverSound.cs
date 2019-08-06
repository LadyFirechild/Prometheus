using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSound : MonoBehaviour
{

    public AudioSource leverSource;
    public AudioClip leverClip;
    public bool stillTriggered = false;
    public float timesPlayed = 0;




    void Start()
    {
        leverSource.clip = leverClip;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Moveable")
        {

            if (timesPlayed == 0 && stillTriggered == false)
            {
                leverSource.Play();
                timesPlayed++;
                stillTriggered = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Moveable")
        {
            stillTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Moveable")
        {
            timesPlayed = 0;
            stillTriggered = false;
        }
    }
}
