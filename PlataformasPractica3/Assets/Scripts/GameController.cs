using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    private int itemsRestantes;
    private int puntos;
    private int vidas;
    private int nivelActual;
    
    [SerializeField] private UnityEngine.UI.Text textoGameOver;
    public UnityEngine.UI.Text textoVida;
    public UnityEngine.UI.Text textoItem;
    public UnityEngine.UI.Text textoNivel;
    
    // Start is called before the first frame update
    void Start()
    {
        itemsRestantes = FindObjectsOfType<Items>().Length;
        puntos = FindObjectOfType<GameStatus>().puntos;
        vidas = FindObjectOfType<GameStatus>().vidas;
        nivelActual = FindObjectOfType<GameStatus>().nivelActual;
        textoGameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            AvanzarNivel();
        }
    }

    public void AnotarItemRecogido()
    {
        puntos = FindObjectOfType<GameStatus>().puntos = puntos;
        puntos += 100;
        textoItem.text = "Puntos: " + puntos.ToString();
        Debug.Log("Puntos: " + puntos);

        itemsRestantes--;
        Debug.Log("Items restantes: " + itemsRestantes);

        if (itemsRestantes <= 0)
        {
            AvanzarNivel();
        }
    }

    public void PerderVida()
    {
        vidas = FindObjectOfType<GameStatus>().vidas = vidas; 
        vidas--;
        FindObjectOfType<Player>().SendMessage("Recolocar");
        textoVida.text = "Vidas: " + vidas.ToString();
        Debug.Log("Vidas: " + vidas);
        if (vidas <= 0 )
        {
           StartCoroutine(TerminarPartida());
            
        }
    }
    
    private IEnumerator TerminarPartida()
    {
        textoGameOver.enabled = true;
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
         Debug.Log("Partida terminada");
                    Application.Quit();
    }
    
    public void AvanzarNivel()
    {
       /*nivelActual++;
        if (nivelActual > FindObjectOfType<GameStatus>().nivelMasAlto)
            nivelActual = 1;
        nivelActual = FindObjectOfType<GameStatus>().nivelActual;
        SceneManager.LoadScene("Nivel" + nivelActual);*/
        //SceneManager.LoadScene("Nivel2" );
        if(SceneManager.sceneCountInBuildSettings == 1)
            Debug.Log("Fin");
        SceneManager.LoadScene("Nivel2");
        //SceneManager.LoadScene("Menu");
        textoNivel.text = "Nivel: " + nivelActual.ToString();
        itemsRestantes = 0;
    }
}
