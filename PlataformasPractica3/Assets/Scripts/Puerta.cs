using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ainhoa Izquierdo Arenas

public class Puerta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Player")
       {
           Destroy(gameObject);
           int level = FindObjectOfType<GameStatus>().nivelActual;
           FindObjectOfType<GameStatus>().SendMessage("LevelUp");
           if (SceneManager.sceneCountInBuildSettings - 2 > level)
           {
               SceneManager.LoadScene("Nivel" + (level + 1));
           }
           else
           {
               SceneManager.LoadScene("Nivel2");
           }
       }
   }
}
