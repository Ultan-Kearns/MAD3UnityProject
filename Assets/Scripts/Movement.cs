using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //variable for player speed
    public float speed = 3f;
    public float jump = 5f;
    // Start is called before the first frame update
    Rigidbody2D rb;
    GameObject player = GameObject.Find("Player");
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump(null);
    }
    private void PlayerMove()
    {
        //have an input from user
        var deltaX = Input.GetAxis("Horizontal");
        //Add the position where player is going to be and give them speed
        var newXPos = deltaX * speed;
        rb.velocity = new Vector2(newXPos, rb.velocity.y);
    }
    //need to see if box collider is detecting collistions
    void PlayerJump(Collision col)
    {
        var deltaY = Input.GetAxis("Vertical");
        var posY = deltaY * jump;
        if (col.gameObject.name == "player")
        {
            rb.velocity = new Vector2(rb.velocity.x, posY);
        }
    }
}


