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
    bool didJump;
    bool isGrounded;
    public Transform isOnPlatform;
    public float platformRadius;
    public LayerMask checkLayerPlatform;
    int timer = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");

        PlayerMove();
        if (timer > 0)
        {
            timer--;
            Debug.Log(timer);
        }
        if (timer == 0)
        {
            didJump = false;
        }

        //use a circle collider on bottom of player to check if the player is on a platform
        //takes in the platform positions the radius of the colldier and to see if player is on right layer
        isGrounded = Physics2D.OverlapCircle(isOnPlatform.position, platformRadius, checkLayerPlatform);
        Debug.Log(isGrounded);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerJump();
        }
        //check if player is off platform and height
        if (player.transform.position.y <= -20 && isGrounded == false)
        {
            Debug.Log("Assume player is dead - EndGame");
        }
    }

    private void PlayerMove()
    {
        //have an input from user
        var deltaX = Input.GetAxis("Horizontal");
        //Add the position where player is going to be and give them speed
        var newXPos = deltaX * speed;
        rb.velocity = new Vector2(newXPos, rb.velocity.y);
    }
    //need to see if box collider is detecting collisions
    void PlayerJump()
    {
        var deltaY = Input.GetAxis("Vertical");
        var posY = deltaY * jump;
        rb.velocity = new Vector2(rb.velocity.x, posY);
        didJump = true;
        timer = 20;
        Debug.Log("IN JUMP");
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Ground")
        {
            Debug.Log("Collided");

        }
    }
}


