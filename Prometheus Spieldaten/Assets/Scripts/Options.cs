﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject OptionsUI;


   


    public void OpenPanel()
    {
        if (OptionsUI != null)
        {
            bool isActice = OptionsUI.activeSelf;

            OptionsUI.SetActive(!isActice);

        }
    }

    public void Zurück()
    {
        if (OptionsUI != null)
        {
            bool isActice = OptionsUI.activeSelf;

            OptionsUI.SetActive(!isActice);

        }
    }

}
