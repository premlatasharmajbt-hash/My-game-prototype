using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    public float time = 4;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            SceneManager.LoadScene("SampleScene 2");
        }
    }
}
