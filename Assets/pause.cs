using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject TextMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.activeInHierarchy == false)
            {
                PauseMenu.SetActive(true);
                TextMenu.SetActive(false);
                Time.timeScale = 0;
            }
            else if (PauseMenu.activeInHierarchy == true)
            {
                UnPause();
            }
        }
    }
    public void UnPause()
    {
        PauseMenu.SetActive(false);
        TextMenu.SetActive(true);
        Time.timeScale = 1;
    }
}
