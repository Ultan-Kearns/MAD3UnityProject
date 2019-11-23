using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 10f;
    int score = 0;
    //if bullet count gets greater than certain amount then increment wave
    int wave = 1;
    int bulletCount = 0;
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
            score += 10;
            bulletCount++;
            //update the wave and add speed to bullets
            if (bulletCount > 20 && wave < 10){
                wave++;
                speed += 1;
            }
        }
     
    }
 //need to allow bullets to pass through player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        Movement.decrementLives(1);
        Destroy(gameObject);
        //May insert audio here to notify user that they have been hit
        //on collision end game
        if (Movement.getLives() < 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
