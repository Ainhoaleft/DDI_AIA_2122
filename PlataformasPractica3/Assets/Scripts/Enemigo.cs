using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class Enemigo : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;

    [SerializeField] float velocidad = 5f;

    [SerializeField] float distaciaCambio = 0.2f;

    private byte siguientePosicion = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            wayPoints[siguientePosicion].transform.position,
            velocidad * Time.deltaTime);
        
        if (Vector3.Distance(transform.position,
                wayPoints[siguientePosicion].transform.position) < distaciaCambio)
        {
            siguientePosicion++;
            if (siguientePosicion >= wayPoints.Count)
                siguientePosicion = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<GameController>().SendMessage("PerderVida");
    }
}
