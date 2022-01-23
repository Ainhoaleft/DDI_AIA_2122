using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints; 
    float velocidad = 2; 
    float distanciaCambio = 0.2f; 
    int numeroSiguientePosicion = 0;
     Vector3 siguientePosicion;
     
     //[SerializeField] Transform prefabDisparoEnemigo = null;
    //[SerializeField] float velocidadDisparo = 2;
     
    // Start is called before the first frame update
    void Start()
    {
        siguientePosicion = wayPoints[0].position;
        //StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {
        // Nos movemos hacia la siguiente posición
        transform.position = Vector3.MoveTowards(transform.position, 
            siguientePosicion,
            velocidad * Time.deltaTime); 
        
        // Si la distancia al punto es corta cambiamos al siguiente
        if (Vector3.Distance(transform.position, 
                siguientePosicion) < distanciaCambio)
        {
            numeroSiguientePosicion++;
            if (numeroSiguientePosicion >= wayPoints.Length) 
                numeroSiguientePosicion = 0;
            
            siguientePosicion = wayPoints[numeroSiguientePosicion].position;
        }

      
    }  
    
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("PerderVida");
    }
}
