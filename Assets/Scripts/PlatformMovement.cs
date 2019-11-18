using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    //change this as it game gets more difficult
    //gets too difficult if > 2.5
    private float speed = 5;
    private Rigidbody2D rb;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        rb.velocity = Vector2.left * speed;
          Debug.Log(rb.gameObject.name);
        //Free up memory after the platform gets out of bounds
        if (gameObject.transform.position.x <= -14)
        {
            Destroy(gameObject);
        }
    }
}
