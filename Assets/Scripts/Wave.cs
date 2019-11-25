using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    static int wave = 1;
    public Text waveText;
    public static int bulletCount = 0;

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave: " + getWave();
    }
    public static void setWave(int newWave)
    {
        wave = newWave;
    }
    public static int getWave()
    {
        return wave;
    }
    public static void reset()
    {
        //reset all
        setWave(1);
        bulletCount = 0;
        Score.scoreNum = 0;
        PlatformMovement.setSpeed(2);
        
    }
}