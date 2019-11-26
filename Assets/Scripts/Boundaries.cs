using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    //CODE ADAPTED FROM MOBILE APPLICATION DEVELOPMENT LABS
     
    public Camera mainCamera;

    private Vector2 screenBounds;

    private float objectWidth =1, objectHeight = 1;
    private float screenwidth = -13, screenheight = -20;

    // Start is called before the first frame update
    void Start()
    {
        // find the screen bounds and convert to unity 
        screenBounds = mainCamera.ScreenToWorldPoint(
                            new Vector3(Screen.width,
                                        Screen.height,
                                        mainCamera.transform.position.z));
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        Debug.Log("SCREEN " + screenBounds.x);
        viewPos.x = Mathf.Clamp(viewPos.x,
                                screenwidth + objectWidth,
                                screenBounds.x - objectWidth);
        //needed to change y so that player can be considered 
        viewPos.y = Mathf.Clamp(viewPos.y,
                                screenheight,
                                screenBounds.y - objectHeight);
        transform.position = viewPos;
    }

}
