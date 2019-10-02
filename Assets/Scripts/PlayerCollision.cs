using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
             Debug.Log("Collided");
    }
}
