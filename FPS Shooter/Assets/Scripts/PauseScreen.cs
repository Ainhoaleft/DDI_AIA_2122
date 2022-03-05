using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ainhoa Izquierdo Arenas

public class PauseScreen : MonoBehaviour
{
    public string mainMenuScene;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    //Pausa
    public void Resume()
    {
        GameManager.instance.PauseUnpause();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
