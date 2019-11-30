using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;
    public static bool isHighScore = false;

    // Start is called before the first frame update
    void Start()
    {
        Int32.TryParse(PlayerPrefs.GetString("highscore"), out int highscore);
        gameOverText.text += " You got : " + Score.scoreNum + " points! " + " and got to Wave: " + Wave.getWave();
        if (isHighScore == false)
        {
            gameOverText.text += "\nTry to beat the highscore " + highscore;
        }
        else
        {
             gameOverText.text += "\nYOU GOT THE HIGHSCORE: " + highscore;

        }
    }
 
}
