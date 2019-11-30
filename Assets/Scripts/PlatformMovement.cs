using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    //change this as it game gets more difficult
    private static float speed = 2;
    private Rigidbody2D rb;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        rb.velocity = Vector2.left * speed;
        //Free up memory after the platform gets out of bounds
        if (gameObject.transform.position.x <= -14)
        {
            Destroy(gameObject);
        }
    }
    public static void setSpeed(float update)
    {
        speed = update;
    }
    public static float getSpeed()
    {
        return speed;
    }

}
