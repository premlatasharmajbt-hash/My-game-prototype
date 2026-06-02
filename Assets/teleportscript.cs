using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportscript : MonoBehaviour
{
    public GameObject Player;
    public Collider2D col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "SampleScene 2")
            {
                SceneManager.LoadScene("Level1");
            }
            else if (currentScene.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (currentScene.name == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }
            else if (currentScene.name == "Level3")
            {
                SceneManager.LoadScene("PutthemBack");
            }
        }
    }
}
