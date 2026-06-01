using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public GameObject prefab; // The prefab to spawn
    public GameObject prefab2; // The second prefab to spawn
    public float spawnInterval; // Time between spawns in seconds
    private float timer; // Timer to track time between spawns
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnInterval = Random.Range(1f, 5f); // Set an initial random spawn interval
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        if (timer >= spawnInterval)
        {
            if (GameObject.Find("Item1(Clone)") == null) // Check if "Item1" does not exist in the scene
            {
                Instantiate(prefab, transform.position, transform.rotation);
                timer = 0; // Reset the timer after spawning
                spawnInterval = 10000000000f; // Set spawn interval to a very large number to prevent further spawns    
            }
            else if (GameObject.Find("Item2(Clone)") == null) // Check if "Item2" does not exist in the scene
            {
                Instantiate(prefab2, transform.position, transform.rotation);
                timer = 0; // Reset the timer after spawning
                spawnInterval = 10000000000f; // Set spawn interval to a very large number to prevent further spawns    
            }
        }    
    }
}
