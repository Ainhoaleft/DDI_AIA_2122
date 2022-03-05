using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ainhoa Izquierdo Arenas

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float waitAfterDying = 2f;

    [HideInInspector]
    public bool levelEnding;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Cursos del ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Cunado le das al escape se pausa el juego
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            PauseUnpause();
        }
    }

    //Carga la escena actual cuando muere el jugador
    public void PlayerDied()
    {
        StartCoroutine("PlayerDiedCo");
    }

    public IEnumerator PlayerDiedCo()
    {
        yield return new WaitForSeconds(waitAfterDying);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //La escena de pausa
    public void PauseUnpause()
    {
        if(UIController.instance.pauseScreen.activeInHierarchy)
        {
            UIController.instance.pauseScreen.SetActive(false); ;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1f;

            PlayerController.instance.footstepSlow.Play();
            PlayerController.instance.footstepFast.Play();
        } else
        {
            UIController.instance.pauseScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Los objetos dejara de moverse
            Time.timeScale = 0f;

            PlayerController.instance.footstepSlow.Stop();
            PlayerController.instance.footstepFast.Stop();
        }
    }
}
