using UnityEngine;

public class spawnit : MonoBehaviour
{
    public GameObject Item1;
    public GameObject Item2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Instantiate(Item1,transform.position,transform.rotation);
       Instantiate(Item2, transform.position + new Vector3(2, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
