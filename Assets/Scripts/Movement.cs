using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //variable for player speed
    public float speed = 3f;
    public float jump = 5f;
    // Start is called before the first frame update
    Rigidbody2D rb;
    //these detect if the player is touching the ground
    bool isGrounded;
    public Transform isOnPlatform;
    public float platformRadius;
    public LayerMask checkLayerPlatform;
    //will hold audio for player
    public AudioSource audio;
    public AudioClip jumpSound;
    GameObject player;
    public Sprite playerJump, playerModel;
    //change with difficulty - for lives default 2 lives
    public static int lives = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //get audio source
        audio = GetComponent<AudioSource>();
        //set the clip to be this initially
        audio.clip = jumpSound;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMove();

        //use a circle collider on bottom of player to check if the player is on a platform
        //takes in the platform positions the radius of the colldier and to see if player is on right layer
        isGrounded = Physics2D.OverlapCircle(isOnPlatform.position, platformRadius, checkLayerPlatform);
        Debug.Log(isGrounded);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
        //check if player is off platform and height
        if (player.transform.position.y <= -20 && isGrounded == false)
        {
            Debug.Log("Assume player is dead - EndGame");
            Dead();
        }
        if(isGrounded == false)
            player.gameObject.GetComponent<SpriteRenderer>().sprite = playerJump;
        if(isGrounded == true)
            player.gameObject.GetComponent<SpriteRenderer>().sprite = playerModel;
    }

    private void Dead()
    {
     
        //also change to gameover screen
        SceneManager.LoadScene(2);
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
        var posY = jump;
        rb.velocity = new Vector2(rb.velocity.x, posY);
        audio.Play();
    }
    public static void decrementLives(int hit)
    {
        lives -= hit;
        Debug.Log("hits " + lives);
    }
    public static int getLives()
    {
        return lives;
    }
}