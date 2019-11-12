using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // get the main camera
    // get the bounds of it (X,Y) - half the size
    // use Mathf.Clamp to compare the min, max to the current x
 

     private Vector2 boundary;
    private float playerWidth;
 
    // Start is called before the first frame update
    void Start()
    {
        // Setup boundary to ensure player does not go beyond screen width
        boundary = Camera.main.ScreenToWorldPoint(
                                new Vector3(Screen.width,
                                            Screen.height,
                                            Camera.main.transform.position.z));
         playerWidth = gameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
        Debug.Log(boundary);
         }

    //need to check player is in bounds after player moves
    private void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        // find the position of X and clamp
        viewPosition.x = Mathf.Clamp(viewPosition.x,
                                Screen.width,
                                Screen.width * -1);
        viewPosition.x = Mathf.Clamp(viewPosition.y,
                        Screen.height,
                        Screen.height * -1);
  
        //set transform to view position to ensure player doesn't go past boundary
        transform.position = viewPosition;
    }
}


