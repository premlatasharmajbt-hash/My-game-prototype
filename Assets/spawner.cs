using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject Prefab;
    private float timer = 0;
    public float spawnrate = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       timer += Time.deltaTime;
       if (timer >= spawnrate)
       {
        Instantiate(Prefab,transform.position,transform.rotation);
        timer = 0;
       }
    }
}
