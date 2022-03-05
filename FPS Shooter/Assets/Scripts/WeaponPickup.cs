using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class WeaponPickup : MonoBehaviour
{
    public string theGun;
    
    private bool collected;

    //Cunado cojamos el pick up del arma se añadira a la mano
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !collected)
        {
            PlayerController.instance.AddGun(theGun);

            Destroy(gameObject);

            collected = true;

            AudioManager.instance.PlaySFX(4);
        }
    }
}
