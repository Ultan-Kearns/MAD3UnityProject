using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    bool test = false;
    // Start is called before the first frame update
    bool callGenerate = false;
    int positionX = 10;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update() {
        if(callGenerate == false)
        {
            testGenerate();
            callGenerate = true;
        }

     }
    
    void testGenerate()
    {
        GameObject platform = GameObject.Find("Platform");
        Vector3 newPos = new Vector3(positionX, -5, 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        var clone = Instantiate(platform,newPos,rotation);
        //use posX variable to set the position of clones
        //need to find way to update
        Debug.Log(positionX);
         if(clone.transform.position.x == -10)
        {
            Destroy(clone);
        }
    }
}
