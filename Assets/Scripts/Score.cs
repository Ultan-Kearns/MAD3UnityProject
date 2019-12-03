using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public static int  scoreNum = 0;
    public static int scoreMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + scoreNum;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreNum;
    }
}
