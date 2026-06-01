using UnityEngine;

public class playscript : MonoBehaviour
{
    public GameObject GameObject;
    public GameObject Game;
    public GameObject Grid;
    public GameObject Player;
    public GameObject Box;
    public GameObject Exit;
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Loading;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Check if the space key is pressed
        {
            Game.SetActive(true); 
            Grid.SetActive(true); 
            Player.SetActive(true); 
            Box.SetActive(true);
            Exit.SetActive(true); 
            GameObject.SetActive(false);
            Item2.SetActive(false);
            Item1.SetActive(false);
        }
        if (GameObject.Find("Item1(Clone)") != null)
        {
         if (GameObject.Find("Item2(Clone)") != null)
         {
            Loading.SetActive(false);
         }   
        }
        if (GameObject.Find("Item2(Clone)") != null)
        {
            if (GameObject.Find("Item1(Clone)") != null)
            {
                Loading.SetActive(false);
            }
        }   
    }
}

