using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float jumpheight = 5f;
    public bool IsGrounded;
    public Rigidbody2D rb;
    public float speed = 5f;

    void Update()
    {
        // Movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpheight;
            IsGrounded = false; // Set to false immediately so they can't double jump
        }
    }

    // This must be OUTSIDE of Update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            IsGrounded = false;
        }
    }
}
