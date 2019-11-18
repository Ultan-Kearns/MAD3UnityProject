using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Difficulty : MonoBehaviour
{
    public Dropdown dd;
    public string ddText;
    // Start is called before the first frame update
    void Start()
    {
        //dropdown menu
        dd = GetComponent<Dropdown>();
        //Listener for drop down menu
        dd.onValueChanged.AddListener(delegate {
            onChange(dd);
            ddText = dd.value.ToString().ToLower();
            setDifficulty(ddText);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void setDifficulty(string difficulty)
    {
        switch (difficulty) { 
            case "0":
                Movement.lives = 3;
                break;
            case "1":
                Movement.lives = 2;
                break;
            case "2":
                Movement.lives = 1;
                break;
            case "3":
                Movement.lives = 0;
                break;
        }
    }
    void onChange(Dropdown dropdown)
    {
        ddText = dropdown.value.ToString().ToLower();
    }
}
