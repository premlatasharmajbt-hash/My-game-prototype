using UnityEngine;

public class spawnaftergame : MonoBehaviour
{
    public GameObject Item1; // The prefab to spawn
    public GameObject Item2; // The prefab to spawn
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)) // Check if the space key is pressed
        {
            Destroy(GameObject.Find("Item2(Clone)"));
            Destroy(GameObject.Find("Item1(Clone)")); // Destroy the "Item1 and others" GameObject if it exists in the scene
            Instantiate(Item1, transform.position, transform.rotation); // Instantiate the "Item1 and others" GameObject at the position and rotation of the spawnaftergame GameObject
            Instantiate(Item2, transform.position, transform.rotation);        
        }
    }
}
