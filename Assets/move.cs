using UnityEngine;

public class move : MonoBehaviour
{
    public float deadzone; 
    public Rigidbody2D rb;
    public float movespeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector2.right * movespeed;
        if (transform.position.x > deadzone)
        {
            Destroy(gameObject);
        }
    }
}
