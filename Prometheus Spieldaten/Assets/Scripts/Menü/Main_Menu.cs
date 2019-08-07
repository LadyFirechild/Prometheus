using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Trailer");
    }

    public void OptionsMain()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is Exiting");
    }
}
