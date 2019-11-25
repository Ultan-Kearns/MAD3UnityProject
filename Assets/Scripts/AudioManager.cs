using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip medium, hard, harder, hardest;

    public AudioSource audioSource;
    private void Start()
    {
        medium = Resources.Load<AudioClip>("Audio/Easy");
        hard = Resources.Load<AudioClip>("Audio/Hard");
        harder = Resources.Load<AudioClip>("Audio/Harder");
        hardest = Resources.Load<AudioClip>("Audio/Hardest");  

    }
    public void setAudio()
    {
        //set audio and audiosource
         if (Wave.getWave() >= 2 && Wave.getWave() < 4)
        {
            //returning sound file but not changing
            Camera.main.GetComponent<AudioSource>().clip = medium;
             Camera.main.GetComponent<AudioSource>().Play();
        }
        else if (Wave.getWave() >= 4 && Wave.getWave() < 6)
        {
            audioSource.clip = hard;
            audioSource.Play();
        }
        else if (Wave.getWave() >= 6 && Wave.getWave() < 8)
        {
            audioSource.clip = harder;
            audioSource.Play();
        }
        else if (Wave.getWave() > 8)
        {
            audioSource.clip = hardest;
            audioSource.Play();
        }
    }
}
