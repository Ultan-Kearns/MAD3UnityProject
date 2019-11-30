using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBullets : MonoBehaviour
{
    public GameObject bullet;
    static float delay = 2f;

    public void Start()
    {
        //start coroutine
        StartCoroutine(bulletWave());
    }

    private void spawnBullet()
    {
        //instantiate the bullet
        GameObject clone = Instantiate(bullet);
        //set the position of new bullet
        clone.transform.position = new Vector2(Random.Range(40,60), Random.Range(0, 11));
    }
    public static void setDelay(float newDelay)
    {
        delay = newDelay;
    }
    public static float getDelay()
    {
        return delay;
    }
    IEnumerator bulletWave()
    {
        while (true)
        {
            //wait until time is up to return new bullet
            yield return new WaitForSeconds(delay);
            spawnBullet();
        }
    }
}