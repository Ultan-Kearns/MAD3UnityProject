using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * speed;
 
        //Free up memory after the platform gets out of bounds
        if (gameObject.transform.position.x <= -14)
        {
            Destroy(gameObject);
        }
        //this is temporary need to get collider on player
        if(gameObject.transform.position.x == GameObject.Find("Player").transform.position.x)
        {
            Destroy(GameObject.Find("Player"));
        }
    }
}
