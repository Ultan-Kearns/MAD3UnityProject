using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    static int wave = 1;
    public Text waveText;
    public static int bulletCount = 0;
    static AudioManager am = new AudioManager();
    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave: " + getWave();
    }
    public static void setWave(int newWave)
    {
        wave = newWave;
        //so song will not change unless game calls for it round 1 added for mute
        if(getWave() == 1||getWave() == 2 || wave == 4 || wave == 6 || wave == 8)
            am.setAudio();
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
        BulletMovement.speed = 10;
        Score.scoreMultiplier = getWave();
    }
}