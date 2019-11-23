using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platform;
    private float delay = 3.5f;
    public Sprite  platform1, platform2,platform3,platform4;
    public void Start()
    {
        //start coroutine
        StartCoroutine(PlatformWave());
    }

    private void SpawnPlatform()
    {
        GameObject clone = platform;
        if (Wave.getWave() >= 2 && Wave.getWave() < 4)
        {
            clone.gameObject.GetComponent<SpriteRenderer>().sprite = platform1;
        }
        else if(Wave.getWave() >= 4 && Wave.getWave() < 6)
        {
            clone.gameObject.GetComponent<SpriteRenderer>().sprite = platform2;
        }
        else if (Wave.getWave() >= 6 && Wave.getWave() < 8)
        {
            clone.gameObject.GetComponent<SpriteRenderer>().sprite = platform3;
        }
        else if(Wave.getWave() > 8)
        {
            clone.gameObject.GetComponent<SpriteRenderer>().sprite = platform4;
        }
        
        //instantiate the platform
        clone = Instantiate(platform);
        //set the position of new platform
        clone.transform.position = new Vector2(Random.Range(20, 30), Random.Range(-3, 10));

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

