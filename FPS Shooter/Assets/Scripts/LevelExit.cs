﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    public string nextLevel;

    public float waitToEndLevel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.levelEnding = true;

            StartCoroutine("EndLevelCo");

            AudioManager.instance.PlayLevelVictory();
        }
    }

    IEnumerator EndLevelCo()
    {
        PlayerPrefs.SetString(nextLevel + "_cp", "");
        PlayerPrefs.SetString("CurrentLevel", nextLevel);

        yield return new WaitForSeconds(waitToEndLevel);

        SceneManager.LoadScene(nextLevel);
    }
}
