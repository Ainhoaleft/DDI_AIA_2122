using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class BouncePad : MonoBehaviour
{
    public float bounceForce;
    
    //Plataforma de salto
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.Bounce(bounceForce);

            AudioManager.instance.PlaySFX(0);
        }
    }
}
