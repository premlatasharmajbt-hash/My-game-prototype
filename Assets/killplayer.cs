using UnityEngine;
using UnityEngine.SceneManagement;

public class killplayer : MonoBehaviour
{
    public GameObject Player;
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
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
