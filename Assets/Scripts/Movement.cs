using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //variable for player speed
    public float speed = 3f;
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }
    private void Move()
    {
        //have an input from user
        var deltaX = Input.GetAxis("Horizontal");
        //Add the position where player is going to be and give them speed
        var newXPos = deltaX * speed;
        rb.velocity = new Vector2(newXPos, rb.velocity.x);
 

    }
}
