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
    public AudioClip death;
    public AudioClip jumpSound;
    GameObject player;
    public Sprite playerJump, playerModel;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //get audio source
        audio = GetComponent<AudioSource>();
        //set the clip to be this initially
        audio.clip = jumpSound;
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
            player = GameObject.Find("Player");
        }
        //check if player is off platform and height
        if (player.transform.position.y <= -20 && isGrounded == false)
        {
            Debug.Log("Assume player is dead - EndGame");
            Dead();
        }
    }

    private void Dead()
    {
        audio.clip = death;
        audio.Play();
        Debug.Log(death);
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
        this.gameObject.GetComponent<SpriteRenderer>().sprite = playerJump;
        var posY = jump;
        rb.velocity = new Vector2(rb.velocity.x, posY);
        audio.Play();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = playerModel;

    }
}