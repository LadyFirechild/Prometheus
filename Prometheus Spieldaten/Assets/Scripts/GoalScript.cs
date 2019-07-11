using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{

    public Fire_Counter FireCounter;

    void Update()
    {
        if(FireCounter.collectible == FireCounter.activeFires)
        {
            SceneManager.LoadScene("");
        }
    }

}
