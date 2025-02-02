﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class Explosion : MonoBehaviour
{
    public int damage = 10;

    public bool damageEnemy, damagePlayer;

    private void OnTriggerEnter(Collider other)
    {
        //Cuando explote al enemigo
        if (other.gameObject.tag == "Enemy" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage);
        }
        //Cuando explote al jugador
        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            //Debug.Log("Hit player at " + transform.position);
            PlayerHealthController.instance.DamagePlayer(damage);
        }
    }
}
