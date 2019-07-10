using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Counter : MonoBehaviour
{

    public int collectible = 0;

    public int activeFires;

    void Start()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Fire"))
        {
            collectible++;
        }

    }

    private void OnEnable()
    {
        GlobalEvent.ActivatedFire += ActivatedFire;
    }

    private void OnDisable()
    {
        GlobalEvent.ActivatedFire -= ActivatedFire;
    }

    void ActivatedFire(GameObject activ)
    {
        activeFires++;
        Debug.Log(activ.name + " " + activ.transform.position);

    }
}
