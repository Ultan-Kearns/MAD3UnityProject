using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platform;
    float delay = 3.5f;
    public void Start()
    {
        //start coroutine
        StartCoroutine(PlatformWave());
    }

    private void SpawnPlatform()
    {
        //instantiate the platform
        GameObject clone = Instantiate(platform);
        //set the position of new platform
        clone.transform.position = new Vector2(Random.Range(20,30), Random.Range(-3, 10));

     }
    IEnumerator PlatformWave()
    {
        while (true)
        {
            //wait until time is up to return new platform
            yield return new WaitForSeconds(delay);
            SpawnPlatform();
        }
    }
}

