using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemDrag : MonoBehaviour
{
    // FIX: Made static so it is remembered across scenes, 
    // and added a flag so it only saves the layout position ONCE.
    private static Vector3 originalPosition;
    private static bool isPositionSaved = false;

    public GameObject Dropbox1;
    public GameObject Dropbox2;
    public GameObject Dropbox3;
    public GameObject Dropbox4;
    public GameObject Dropbox;
    private Vector3 screenPoint;
    private Vector3 offset;
    
    public bool touchingDropBox;
    public bool touchingDropBox1;
    public bool touchingDropBox2;
    public bool touchingDropBox3;
    public bool touchingDropBox4;
    public float timetosee = 10f;
    
    public static float timer = 0f; 
    public static bool won;
    public bool notagain = false;
    
    private float initialZ;

    void Start()
    {
        // FIX: Only record the absolute original position the first time the game starts.
        // It will now remember this exact position even when you switch scenes.
        if (!isPositionSaved)
        {
            originalPosition = transform.position;
            isPositionSaved = true;
        }

        initialZ = transform.position.z;
        
        // Reset the shared timer and win state for the new scene run
        timer = 0f;
        won = false; 
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        
        curPosition.z = initialZ; 
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        if (touchingDropBox && Dropbox != null)
        {
            Vector3 targetPos = Dropbox.transform.position;
            targetPos.z = Dropbox.transform.position.z - 1f; 
            transform.position = targetPos;
        }
        if (touchingDropBox1 && Dropbox1 != null)
        {
            Vector3 targetPos = Dropbox1.transform.position;
            targetPos.z = Dropbox1.transform.position.z - 1f; 
            transform.position = targetPos;
        }
        if (touchingDropBox2 && Dropbox2 != null)
        {
            Vector3 targetPos = Dropbox2.transform.position;
            targetPos.z = Dropbox2.transform.position.z - 1f; 
            transform.position = targetPos;
        }
        if (touchingDropBox3 && Dropbox3 != null)
        {
            Vector3 targetPos = Dropbox3.transform.position;
            targetPos.z = Dropbox3.transform.position.z - 1f; 
            transform.position = targetPos;
        }
        if (touchingDropBox4 && Dropbox4 != null)
        {
            Vector3 targetPos = Dropbox4.transform.position;
            targetPos.z = Dropbox4.transform.position.z - 1f; 
            transform.position = targetPos;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Dropbox)
        {
            touchingDropBox = true;
        }
        else if (other.gameObject == Dropbox1)
        {
            touchingDropBox1 = true;
        }
        else if (other.gameObject == Dropbox2)
        {
            touchingDropBox2 = true;
        }
        else if (other.gameObject == Dropbox3)
        {
            touchingDropBox3 = true;
        }
        else if (other.gameObject == Dropbox4)
        {
            touchingDropBox4 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {  
        if (other.gameObject == Dropbox)
        {
            touchingDropBox = false;
        }
        else if (other.gameObject == Dropbox1)
        {
            touchingDropBox1 = false;
        }
        else if (other.gameObject == Dropbox2)
        {
            touchingDropBox2 = false;
        }
        else if (other.gameObject == Dropbox3)
        {
            touchingDropBox3 = false;
        }
        else if (other.gameObject == Dropbox4)
        {
            touchingDropBox4 = false;
        }
    }

    void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "PutthemBack")
        {
            timer += Time.deltaTime; 
            
            if (timer > timetosee)
            {
                if (Vector3.Distance(transform.position, originalPosition) < 0.1f)
                {
                   
                    Debug.Log("You WON");
                    won = true;
                    if (timer >= 20)
                    {
                        SceneManager.LoadScene("thanks for playing");
                        enabled = false; 
                    }
                }
                else
                {
                    Debug.Log("YOU lost");
                    won = false;
                    if (timer >= 20)
                    {
                        SceneManager.LoadScene("thanks for playing");
                        enabled = false; 
                    }
                }
            }
        }
    }
}
