using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platform;
    float delay = 2f;
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
        clone.transform.position = new Vector2(Random.Range(-13,11), Random.Range(0, 10));

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

