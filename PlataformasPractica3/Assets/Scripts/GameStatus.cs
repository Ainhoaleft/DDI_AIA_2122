using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas
public class GameStatus : MonoBehaviour
{
    public int puntos = 0;
    public int vidas = 3;
    public int nivelActual = 1;
    public int nivelMasAlto = 1;

    public void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
            Destroy(gameObject);
        
        else
            DontDestroyOnLoad(gameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LevelUp()
    {
        nivelActual++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
