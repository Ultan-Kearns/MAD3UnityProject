using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    static int wave = 1;
    public Text waveText;
    public static int bulletCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

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
}