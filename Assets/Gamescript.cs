using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamescript : MonoBehaviour
{
    public GameObject PauseRestart;
    public GameObject PauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f; // Ensure the game starts unpaused
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ReLoadGame()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadGame1()
    {
        SceneManager.LoadScene("SampleScene 2");
    }
    public void DontRestart()
    {
        PauseRestart.SetActive(false);
        PauseMenu.SetActive(true);
    }
    public void RestartMenu()
    {
        PauseRestart.SetActive(true);
        PauseMenu.SetActive(false);
    }
}
