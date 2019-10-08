using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // get the main camera
    // get the bounds of it (X,Y) - half the size
    // use Mathf.Clamp to compare the min, max to the current x

     public Camera mainCamera;

     private Vector2 boundary;
    private float playerWidth;
 
    // Start is called before the first frame update
    void Start()
    {
        // Setup boundary to ensure player does not go beyond screen width
        //make screen slightly bigger
        boundary = mainCamera.ScreenToWorldPoint(
                                new Vector3(Screen.width * 1.1f,
                                            Screen.height,
                                            mainCamera.transform.position.z));
         playerWidth = gameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
        Debug.Log(boundary);
         }

    //need to check player is in bounds after player moves
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        // find the position of X and clamp
        viewPos.x = Mathf.Clamp(viewPos.x,
                                boundary.x * -1 + playerWidth,
                                boundary.x - playerWidth);
        Debug.Log(boundary.x);
        //set transform to view position to ensure player doesn't go past boundary
        transform.position = viewPos;
    }
}


