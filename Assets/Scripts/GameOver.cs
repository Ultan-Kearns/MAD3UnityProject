using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;
    public bool isHighScore = false;

    // Start is called before the first frame update
    void Start()
    { 
        //check if highscore
        Int32.TryParse(PlayerPrefs.GetString("highscore"), out int highscore);
        Debug.Log("HIGH " + highscore);
        if (highscore == 0 && Score.scoreNum > 0)
        {
            isHighScore = true;
            PlayerPrefs.SetString("highscore", Score.scoreNum.ToString());
        }
        else if (Score.scoreNum > highscore)
        {
            isHighScore = true;
            PlayerPrefs.SetString("highscore", Score.scoreNum.ToString());
        }
        checkHighScore();
    }

    public void checkHighScore()
    {
        Int32.TryParse(PlayerPrefs.GetString("highscore"), out int highscore);

        if (isHighScore == false)
        {
            gameOverText.text +=  "You got to wave: " + Wave.getWave() + " And had a score of: " + Score.scoreNum + "\nTry to beat the highscore " + highscore;
        }
        else
        {
            gameOverText.text += "You got to wave: " + Wave.getWave() +  " And had a score of: "  + Score.scoreNum + "\nYOU GOT THE HIGHSCORE: " + highscore;

        }
    }
}
