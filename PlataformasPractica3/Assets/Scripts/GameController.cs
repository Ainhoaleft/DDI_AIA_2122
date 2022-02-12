using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ainhoa Izquierdo Arenas
public class GameController : MonoBehaviour
{
   
    private int itemsRestantes;
    private int puntos;
    private int vidas;
    private int nivelActual;
    private Puerta puerta;
    
     private GameStatus gameStatus;
     
    [SerializeField] private UnityEngine.UI.Text textoGameOver;
    public UnityEngine.UI.Text textoVida;
    public UnityEngine.UI.Text textoItem;
    public UnityEngine.UI.Text textoNivel;
    
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
                     
        puntos = gameStatus.puntos;
        puerta = FindObjectOfType<Puerta>();
        vidas = gameStatus.vidas; 
        nivelActual = gameStatus.nivelActual; 
        itemsRestantes = FindObjectsOfType<Items>().Length;
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
     
        puntos += 100;
        gameStatus.puntos = puntos;
        textoItem.text = "Puntos: " + puntos.ToString();
        Debug.Log("Puntos: " + puntos);

        itemsRestantes--;
        
        Debug.Log("Items restantes: " + itemsRestantes);

        if (itemsRestantes <= 0)
        {
            if (puntos == 0)
            {
                puerta.gameObject.SetActive(true);
            }
           
        }
    }

    public void PerderVida()
    {
        vidas--;
        gameStatus.vidas = vidas;
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
    
    private IEnumerator MenuPrincipal()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Partida terminada");
            Application.Quit();
    }
    public void AvanzarNivel()
    {
        nivelActual++;
        if (nivelActual > gameStatus.nivelMasAlto)
            nivelActual = 1; 
        gameStatus.nivelActual = nivelActual; 
  
        SceneManager.LoadScene("Nivel" + nivelActual);

    }
}
