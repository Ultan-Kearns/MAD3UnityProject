using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.name == "Ground")
        {
            Debug.Log("Collided");

        }
        Debug.Log("Collided");
    }
}
