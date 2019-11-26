using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Toggle toggleMute;
    public GameObject source;
    //toggles music on and off
    public void toggle()
    {
        if (toggleMute.isOn == true)
        {
            source.GetComponent<AudioSource>().Pause();
            Debug.Log("Shouldn't play");
        }
        else
        {
            if (toggleMute.isOn == false)
                source.GetComponent<AudioSource>().Play();
            Debug.Log("Should play");
        }
    }
}
