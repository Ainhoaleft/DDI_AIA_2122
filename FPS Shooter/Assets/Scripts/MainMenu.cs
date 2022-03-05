using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ainhoa Izquierdo Arenas

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("CurrentLevel"))
        {
            if(PlayerPrefs.GetString("CurrentLevel") == "")
            {
                continueButton.SetActive(false);
            }
        }else
        {
            continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
    
    //Boton de Continuar
    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
    }

    //Boton del empezar
    public void PlayGame()
    {
        SceneManager.LoadScene(firstLevel);

        PlayerPrefs.SetString("CurrentLevel", "");

        PlayerPrefs.SetString(firstLevel + "_cp", "");

        Time.timeScale = 1f;
    }

    //Boton de Finalizar
    public void QuitGame()
    {
        Application.Quit();
    }
}
