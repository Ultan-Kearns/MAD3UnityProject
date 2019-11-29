using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Toggle toggleMute;
    //toggles music on and off
    public void toggle()
    {
        //if this value is null
        if(PlayerPrefs.GetString("toggle") == null)
        {
            PlayerPrefs.SetString("toggle","False");

        }

        //if true mute else unmute
        if (toggleMute.isOn == true)
        {
            Camera.main.GetComponent<AudioSource>().Pause();
            PlayerPrefs.SetString("toggle", "True");
            Debug.Log("shouldn't play");
        }
        else
        {
            Camera.main.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetString("toggle", "False");
            Debug.Log("Should play");
 
        }
     }
 
}
