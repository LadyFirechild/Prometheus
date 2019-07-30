using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoalTutorial : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D trigger)
    {
        SceneManager.LoadScene("FeuerLevel");
    }
}