using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    //lege dieses Script in das entsprechende Canvas wo auch das Menü sich befindet, 
    //ziehe bei PauseMenuUI das Menü/Panel hinein

    public bool GameIsPaused = false;    //setze den Wert ob das Spiel pausiert auf falsch

    public GameObject PauseMenuUI;              //erstelle ein öffentliches Game-Object mit dem Namen Pause
    public GameObject Options;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();                   //rufe die Funktion Resume auf
            }
            else if (!GameIsPaused)
            {
                Pause();                    //rufe die Funktion Pause auf
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Hi");
        Options.SetActive(false);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;                //setze die weiterlaufende Zeit auf 0
        GameIsPaused = true;
    }
}
