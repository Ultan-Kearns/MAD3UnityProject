using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Toggle toggle;
    public void Start()
    {
        if (PlayerPrefs.GetString("toggle") == "True" && SceneManager.GetActiveScene().buildIndex != 2)
        {
            Debug.Log(PlayerPrefs.GetString("toggle"));
            Camera.main.GetComponent<AudioSource>().Pause();
            toggle.GetComponent<Toggle>().isOn = true;
        }
 
    }
    public void Play()
    {
        //reset all
        Wave.reset();
        SceneManager.LoadScene(1);
    }
 
    public void Quit()
    {
        Debug.Log("Start");
        Debug.Log("this should quit game");
        //if in game over screen
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(0);
            //reset all
            Wave.reset();
        }
        else
        {
            Application.Quit();
        }
    }
}
