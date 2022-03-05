using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ainhoa Izquierdo Arenas

public class LevelExit : MonoBehaviour
{

    public string nextLevel;

    public float waitToEndLevel;

    //Cunado toque el portal pasa de nivel
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.levelEnding = true;

            StartCoroutine("EndLevelCo");

            AudioManager.instance.PlayLevelVictory();
        }
    } 
    //Reinicia los checkpoint al pasar de nivel
    IEnumerator EndLevelCo()
    {
        PlayerPrefs.SetString(nextLevel + "_cp", "");
        PlayerPrefs.SetString("CurrentLevel", nextLevel);

        yield return new WaitForSeconds(waitToEndLevel);

        SceneManager.LoadScene(nextLevel);
    }
}
