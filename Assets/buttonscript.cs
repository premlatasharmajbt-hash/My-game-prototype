using UnityEngine;

public class buttonscript : MonoBehaviour
{
    public GameObject Box;
    public GameObject ToggleObject;
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
        if (other.gameObject == Box)
        {
            ToggleObject.SetActive(false);
        }
    }
}
