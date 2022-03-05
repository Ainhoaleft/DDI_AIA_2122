using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ainhoa Izquierdo Arenas

public class Gun : MonoBehaviour
{
    public GameObject bullet;

    public bool canAutoFire;

    public float fireRate;

    [HideInInspector]
    public float fireCounter;

    public int currentAmmo, pickupAmount;

    public Transform firePoint;

    public float zoomAmount;

    public string gunName;
    void Start()
    {
        
    }

    void Update()
    {
        if(fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
    }

    
    //Se actualizará en el texto cuando disparamos balas 
    public void GetAmmo()
    {
        currentAmmo += pickupAmount;

        UIController.instance.ammoText.text = "AMMO: " + currentAmmo;
    }
}
