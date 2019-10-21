using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBullets : MonoBehaviour
{
    /*
     Could use a single class for this and platform spawn to call
         */
    //change this for waves
    float delay = 5f;
    public void Start()
    {
        //start coroutine
        StartCoroutine(BulletWave());
    }

    private void SpawnBullet()
    {
        var random = new System.Random();
        GameObject bullet = GameObject.Find("Bullet");
        //instantiate the bullet
        Vector3 newPos = new Vector3(random.Next(0, 30), random.Next(0, 10), 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        GameObject clone = Instantiate(bullet,newPos,rotation);
        //set the position of new bullet, always make it appear from right side of screen
        clone.transform.position = new Vector2(11, Random.Range(0, 10));
        if (clone.transform.position.x == -10)
        {
            Destroy(clone);
        }
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
