using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBullets : MonoBehaviour
{
    /*
     Could use a single class for this and platform spawn to call
         */
    public GameObject bullet;
    //change this for waves
    float delay = 3f;
    public void Start()
    {
        //start coroutine
        StartCoroutine(BulletWave());
    }

    private void SpawnBullet()
    {
        //instantiate the bullet
        GameObject clone = Instantiate(bullet);
        //set the position of new bullet, always make it appear from right side of screen
        clone.transform.position = new Vector2(11, Random.Range(0, 10));

    }
    IEnumerator BulletWave()
    {
        while (true)
        {
            //wait until time is up to return new platform
            yield return new WaitForSeconds(delay);
            SpawnBullet();
        }
    }
}
