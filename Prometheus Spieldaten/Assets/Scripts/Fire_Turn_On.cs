using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Turn_On : MonoBehaviour
{
    public ParticleSystem particles;


    void Start()
    {
        particles.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hi");
        if (other.gameObject.tag == "Player")
        {
            if (!particles.gameObject.activeSelf)
            {
                particles.gameObject.SetActive(true);
                GlobalEvent.ActivatedFire?.Invoke(this.gameObject);
            }
        }
    }
}

