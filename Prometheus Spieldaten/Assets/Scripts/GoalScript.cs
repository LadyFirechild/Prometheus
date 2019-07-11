using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public Fire_Counter FireCounter;
    public GameObject Panel;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Panel.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if(FireCounter.collectible == FireCounter.activeFires)
        {
            SceneManager.LoadScene("");
        }
        if(FireCounter.collectible != FireCounter.activeFires)
        {
            Panel.SetActive(true);
        }
    }
}
