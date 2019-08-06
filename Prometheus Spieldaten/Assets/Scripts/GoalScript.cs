using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public Fire_Counter FireCounter;
    public GameObject Panel;

    public GameObject UIEinblend;
   
    public GameObject Ziel_versperrt;
    public GameObject Ziel_geöffnet;

    void Start()
    {
        Panel.SetActive(false);
       
    }


    void Update()
    {
        
        if (FireCounter.collectible == FireCounter.activeFires)
            Destroy(Ziel_versperrt);



    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if(FireCounter.collectible == FireCounter.activeFires)
        {
            SceneManager.LoadScene("Level3");
        }
        if(FireCounter.collectible != FireCounter.activeFires)
        {
            Panel.SetActive(true);


        }
    }
}
