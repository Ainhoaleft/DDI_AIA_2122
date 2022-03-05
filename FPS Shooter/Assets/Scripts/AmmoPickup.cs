using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

//Las balas del jugador
public class AmmoPickup : MonoBehaviour
{
    private bool collected;

//Cuando coja el pick up de la bala
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !collected)
        {
            PlayerController.instance.activeGun.GetAmmo();

            Destroy(gameObject);

            collected = true;

            AudioManager.instance.PlaySFX(3);
        }
    }
}
