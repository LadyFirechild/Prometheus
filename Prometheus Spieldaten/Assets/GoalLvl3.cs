using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalLvl3 : MonoBehaviour
{
    public Fire_Counter FireCounter;
    public GameObject Panel;

    public GameObject Ziel_versperrt;
    public GameObject Ziel_geöffnet;

    public GameObject FeuerOn;
    public GameObject FeuerOff;

    void Start()
    {
        Panel.SetActive(true);
        FeuerOn.SetActive(false);
    }


    void Update()
    {

        if (FireCounter.collectible == FireCounter.activeFires)
        {
            Destroy(Ziel_versperrt);
            FeuerOn.SetActive(true);
            FeuerOff.SetActive(false);
        }


    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (FireCounter.collectible == FireCounter.activeFires)
        {
            SceneManager.LoadScene("Tutorial");
        }

        if (FireCounter.collectible != FireCounter.activeFires)
        {

            Panel.SetActive(true);

        }

      

    }
}
