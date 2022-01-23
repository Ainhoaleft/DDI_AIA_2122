using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class RandomColor : MonoBehaviour
{
    private Renderer r;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        r = GetComponent<Renderer>();
        StartCoroutine( Color() );
       
    }
    
    // Update is called once per frame
    void Update()
    {
       
                              
    }
//Cambiar de color cada 3 segundos en los pick ups
    IEnumerator Color()
    { 
        r.material.color = new Color(Mathf.Round(Random.value), Mathf.Round(Random.value),
                                    Mathf.Round(Random.value));
        yield return new WaitForSeconds(3); 
        StartCoroutine( Color() );
        
    }
}
