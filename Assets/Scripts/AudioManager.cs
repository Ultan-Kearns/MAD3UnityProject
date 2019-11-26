﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip medium, hard, harder, hardest;

    public AudioSource audioSource;
    private void Start()
    {


    }
    public void setAudio()
    {
        //reload data
        //set audio and audiosource
        if (Wave.getWave() >= 2 && Wave.getWave() < 4)
        {
            medium = Resources.Load<AudioClip>("Audio/Medium");

            //returning sound file but not changing
            Camera.main.GetComponent<AudioSource>().clip = medium;
            Camera.main.GetComponent<AudioSource>().Play();
        }
        else if (Wave.getWave() >= 4 && Wave.getWave() < 6)
        {
            hard = Resources.Load<AudioClip>("Audio/Hard");

            Camera.main.GetComponent<AudioSource>().clip = hard;
            Camera.main.GetComponent<AudioSource>().Play();
        }
        else if (Wave.getWave() >= 6 && Wave.getWave() < 8)
        {
            harder = Resources.Load<AudioClip>("Audio/Harder");

            Camera.main.GetComponent<AudioSource>().clip = harder;
            Camera.main.GetComponent<AudioSource>().Play();
        }
        else
        {
            hardest = Resources.Load<AudioClip>("Audio/Hardest");
            Camera.main.GetComponent<AudioSource>().clip = hardest;
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }
}
