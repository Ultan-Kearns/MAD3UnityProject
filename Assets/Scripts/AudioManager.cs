using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip medium, hard, harder, hardest;

    public AudioSource audioSource;
    //check value of options menu mute may link this to pause screen
    public string checkToggle;
    private void Start()
    {
    }
    //this prevents large amounts of stutter when loading audio
    public void loadAudio()
    {
        medium = Resources.Load<AudioClip>("Audio/Medium");
        hard = Resources.Load<AudioClip>("Audio/Hard");
        harder = Resources.Load<AudioClip>("Audio/Harder");
        hardest = Resources.Load<AudioClip>("Audio/Hardest");
    }
    public void setAudio()
    {
        checkToggle = PlayerPrefs.GetString("toggle");
        Debug.Log("CHECK TOGGLE " + checkToggle);
        if (checkToggle == "True")
        {
            Camera.main.GetComponent<AudioSource>().Pause();
        }
        else if (checkToggle == "False")
        {
            //set audio and audiosource
            if (Wave.getWave() == 1)
                return;
            else if (Wave.getWave() >= 2 && Wave.getWave() < 4)
            {
                //returning sound file but not changing
                Camera.main.GetComponent<AudioSource>().clip = medium;
                Camera.main.GetComponent<AudioSource>().Play();
            }
            else if (Wave.getWave() >= 4 && Wave.getWave() < 6)
            {
                Camera.main.GetComponent<AudioSource>().clip = hard;
                Camera.main.GetComponent<AudioSource>().Play();
            }
            else if (Wave.getWave() >= 6 && Wave.getWave() < 8)
            {
                Camera.main.GetComponent<AudioSource>().clip = harder;
                Camera.main.GetComponent<AudioSource>().Play();
            }
            else
            {
                Camera.main.GetComponent<AudioSource>().clip = hardest;
                Camera.main.GetComponent<AudioSource>().Play();
            }
        }
    }

}
