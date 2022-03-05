using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ainhoa Izquierdo Arenas

public class CheckpointController : MonoBehaviour
{
    public string cpName;

    //Donde carga el jugador en el checkpoint
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_cp"))
        {
            if(PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "_cp") == cpName)
            {
                PlayerController.instance.transform.position = transform.position;
                Debug.Log("Player starting at " + cpName);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    //Cunado toca el checkpoint
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "_cp", cpName);
            Debug.Log("Player hit " + cpName);

            AudioManager.instance.PlaySFX(1);
        }
    }
}
