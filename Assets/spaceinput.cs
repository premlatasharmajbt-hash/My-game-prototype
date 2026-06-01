using UnityEngine;
using TMPro;

public class spaceinput : MonoBehaviour
{
    // Make sure to assign this in the Unity Inspector
    public TextMeshProUGUI Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // FIX: Use .text to actually assign the string to the UI component
            Text.text = "Welcome to the world of Telekanisis You Have Telekanises but you are limited because somebody made the objects you pick up go back after some time Defeat the person because uhh i dont know this is a dev build";
        }
    }
}
