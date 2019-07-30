using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{

    public GameObject Panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Panel.SetActive(false);

        }
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        Panel.SetActive(true);
    }


 

}
