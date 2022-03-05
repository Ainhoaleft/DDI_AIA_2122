using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class HealthPickup : MonoBehaviour
{
    private bool isCollected;

    public int healAmount;

    //Cuando cojamos el pick up de la vida se restaura
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !isCollected)
        {
            PlayerHealthController.instance.HealPlayer(healAmount);

            Destroy(gameObject);

            isCollected = true;

            AudioManager.instance.PlaySFX(5);
        }
    }
}
