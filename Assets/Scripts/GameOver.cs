using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text += " You got : " + Score.scoreNum + " points! " + " and got to Wave: " + Wave.getWave();
        Wave.reset();
    }
 
}
