using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire_Counter : MonoBehaviour
{

    public int collectible = 0;

    public int activeFires;

    public Text Feuer;      //stellt Text.UI zur Verfügung

    


    void Start()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Fire"))
        {
            collectible++;
        }

    }

    private void OnEnable()
    {
        GlobalEvent.ActivatedFire += ActivatedFire;
    }

    private void OnDisable()
    {
        GlobalEvent.ActivatedFire -= ActivatedFire;
    }

    void ActivatedFire(GameObject activ)
    {
        activeFires++;
        Debug.Log(activ.name + " " + activ.transform.position);

    }

    void Update()

    {
        // to do: starten sobald am ersten Feuer
        //to do: Layer hinter Zahlen, wegen Sichtbarkeit
        Feuer.text = activeFires + " / " + collectible;     //zeigt in der Text.UI die Feuer an

        // es folgt noch die Aktualisierung des Bildes
        // Bild 1 Feuer fehlen noch
        // Bild 2 alle Feuer zusammen
    }
}
