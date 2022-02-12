using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ainhoa Izquierdo Arenas

public class Escena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameStatus>().puntos = 0;
        FindObjectOfType<GameStatus>().vidas = 3;
        FindObjectOfType<GameStatus>().nivelActual = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LanzarJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
