using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeendenScript : MonoBehaviour
{

    public GameObject Panel;

    public void OpenPanel()
    {
        if(Panel != null)
        {
            bool isActice = Panel.activeSelf;

            Panel.SetActive(!isActice);
          
        }
    }

   /* public void OpenPanels()
    {
        if (Panel != null)
        {
            bool isActice = Panel.activeSelf;

            Panel.SetActive(!isActice);
            Time.timeScale = 1f;
        }
    } */
}
