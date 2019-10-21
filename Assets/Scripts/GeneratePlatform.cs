using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        generatePlatform();

    }

    void generatePlatform()
    {
        var random = new System.Random();
        GameObject platform = GameObject.Find("Platform");
        Vector3 newPos = new Vector3(random.Next(0, 30), random.Next(0, 10), 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        var clone = Instantiate(platform, newPos, rotation);
        //use posX variable to set the position of clones
        //need to find way to update
        if (clone.transform.position.x == -10)
        {
            Destroy(clone);
        }
    }
}
