using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totmann : MonoBehaviour
{
    public GameObject Tür;
    public float timesPlayed;
 
    public AudioSource switchSource;
    public AudioClip switchClip;

    public void Start()
    {
        switchSource.clip = switchClip;

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject)
        {
            Tür.SetActive(false);

            if (!switchSource.isPlaying && timesPlayed == 0)
            {
                switchSource.Play();
                timesPlayed++;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            Tür.SetActive(false);
            //anim.SetActive(true);
        }
    }

}
