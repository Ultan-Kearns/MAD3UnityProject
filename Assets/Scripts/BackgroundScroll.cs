using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed = 20f;
    // Update is called once per frame
    void Update()
    {   //to make background scroll
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * speed), 0f);
    }
}
