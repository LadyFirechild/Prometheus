using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject CreditsUI;

    public void Zurück()
    {
        if (CreditsUI != null)
        {
            bool isActice = CreditsUI.activeSelf;

            CreditsUI.SetActive(!isActice);

        }
    }
}
