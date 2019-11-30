using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //variable for player speed
    public float speed = 10f;
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
    public Sprite playerJumpRight, playerJumpLeft, playerModelRight,playerModelLeft;
    //change with difficulty 
    public static int lives;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //get audio source
        audio = GetComponent<AudioSource>();
        //set the clip to be this initially
        audio.clip = jumpSound;
        player = GameObject.Find("Player");
        //get difficulty
        Difficulty.setDifficulty(Difficulty.getDifficulty());
        Debug.Log("DIFFICULTY " + Difficulty.getDifficulty());
        //calling here for mute
        Wave.setWave(1);
     }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        //use a circle collider on bottom of player to check if the player is on a platform
        //takes in the platform positions the radius of the colldier and to see if player is on right layer
        //adapted from tutorial - https://www.youtube.com/watch?v=QGDeafTx5ug&t=477s
        isGrounded = Physics2D.OverlapCircle(isOnPlatform.position, platformRadius, checkLayerPlatform);
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
        if (isGrounded == false)
        {
            //check if player moves in air and then change to sprites
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player.gameObject.GetComponent<SpriteRenderer>().sprite = playerJumpLeft;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player.gameObject.GetComponent<SpriteRenderer>().sprite = playerJumpRight;
            }
        }
        if (isGrounded == true)
        {
            //change model on ground
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player.gameObject.GetComponent<SpriteRenderer>().sprite = playerModelLeft;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player.gameObject.GetComponent<SpriteRenderer>().sprite = playerModelRight;
            }
        }
    }

    private void Dead()
    {
        //check if highscore
        Int32.TryParse(PlayerPrefs.GetString("highscore"), out int highscore);
        Debug.Log("HIGH " + highscore);
        if (highscore == 0 && Score.scoreNum > 0)
        {
            GameOver.isHighScore = true;
            PlayerPrefs.SetString("highscore", Score.scoreNum.ToString());
        }
        else if (Score.scoreNum > highscore)
        {
            GameOver.isHighScore = true;
            PlayerPrefs.SetString("highscore", Score.scoreNum.ToString());
        }
        //also change to gameover screen
        SceneManager.LoadScene(2);
    }

    //allows player to move left + right
    private void PlayerMove()
    {
        //have an input from user
        var deltaX = Input.GetAxis("Horizontal");
        //Add the position where player is going to be and give them speed
        var newXPos = deltaX * speed;
        //Check if player is on platform if he is move with platform and if he wants to move then call move
        if (isGrounded == true)
        {
            rb.velocity = new Vector2(newXPos + PlatformMovement.getSpeed() * -1, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(newXPos, rb.velocity.y);
        }
    }
    //Allows player to jump and plays funny noise - haha oh wow
    void PlayerJump()
    {
        var posY = jump;
        rb.velocity = new Vector2(rb.velocity.x, posY);
        audio.Play();
    }
   //decrement lives on hit
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