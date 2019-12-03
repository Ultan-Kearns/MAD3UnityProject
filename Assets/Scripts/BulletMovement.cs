using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public static float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * speed;

        //Free up memory after the bullet gets out of bounds

        if (gameObject.transform.position.x <= -14)
        {
            Destroy(gameObject);
            //times score by wave
            Score.scoreNum += 10 * Wave.getWave();
            Wave.bulletCount++;
            //update the wave and add speed to bullets
            if (Wave.bulletCount > 10 * Wave.getWave() && Wave.getWave() < 10)
            {
                newRound();
            }
        }

    }
    //need to allow bullets to pass through player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        Score.scoreNum -= 10 * Wave.getWave();
        Movement.decrementLives(1);
        Destroy(gameObject);
        //May insert audio here to notify user that they have been hit
        //on collision end game
        if (Movement.getLives() < 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void newRound()
    {
        //reset the bullet count
        Wave.bulletCount = 0;
        Wave.setWave(Wave.getWave() + 1);
        Score.scoreMultiplier = Wave.getWave();
        speed += 5;
        PlatformMovement.setSpeed(PlatformMovement.getSpeed() + 1.3f);
        PlatformSpawn.setDelay(PlatformSpawn.getDelay() - 0.3f);
        GenerateBullets.setDelay(GenerateBullets.getDelay() - 0.2f);
    }
}
