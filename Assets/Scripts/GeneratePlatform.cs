using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
    bool test = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { 
  
    }
    
    void testGenerate()
    {
        GameObject platform = GameObject.Find("Platform");
        var clone = Instantiate(platform);
        clone.transform.position.Set(1, 1, 0);
 
    }
}
