using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
     
    }
 //need to allow bullets to pass through player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("dead");
        Movement.setHits(1);
        //on collision end game
        if (Movement.getHits() == 3)
        {
            SceneManager.LoadScene(2);
        }
    }
}
