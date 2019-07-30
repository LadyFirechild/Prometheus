using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totmann : MonoBehaviour
{
    public GameObject Tür;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject)
        {
            Tür.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            Tür.SetActive(false);
        }
    }

}
