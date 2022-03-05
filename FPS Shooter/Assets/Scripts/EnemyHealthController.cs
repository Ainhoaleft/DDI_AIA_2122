using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class EnemyHealthController : MonoBehaviour
{
    //La vida del enemigo
    public int currentHealth = 5;

    public EnemyController theEC;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //La vida del enemigo
    public void DamageEnemy(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(theEC != null)
        {
            theEC.GetShot();
        }

        if(currentHealth <= 0)
        {
            Destroy(gameObject);

            AudioManager.instance.PlaySFX(2);
        }
    }
}
