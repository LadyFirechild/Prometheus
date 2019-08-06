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

    public GameObject FeuerOn;
    public GameObject FeuerOff;

    void Start()
    {
        Panel.SetActive(false);
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
        if(FireCounter.collectible == FireCounter.activeFires)
        {
            SceneManager.LoadScene("Level3");
        }
        if(FireCounter.collectible != FireCounter.activeFires)
        {
           
            UIEinblend.SetActive(true);
            StartCoroutine(Example());
            
        }

        IEnumerator Example()

        {
            yield return new WaitForSeconds(1);
            Destroy(UIEinblend);
            Panel.SetActive(true);
        }

          
    }
}
