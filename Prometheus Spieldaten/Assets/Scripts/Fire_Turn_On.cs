using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Turn_On : MonoBehaviour
{
    public ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            particles.gameObject.SetActive(true);
            GlobalEvent.ActivatedFire?.Invoke(this.gameObject);
        }
    }
}

