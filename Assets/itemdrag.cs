using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemDrag : MonoBehaviour
{
    private static Vector3 originalPosition;
    
    // SYSTEM FIX: Changed to static so the script remembers it already saved the position across scenes
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
    
    private float initialZ;

    void Start()
    {
       if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (SceneManager.GetActiveScene().name != "SampleScene 1" && SceneManager.GetActiveScene().name != "SampleScene" && SceneManager.GetActiveScene().name != "PutthemBack")
        {
           Destroy(gameObject);
        }
        // Now this only runs the very first time the item is created in the first scene
        if (!isPositionSaved)
        {
            originalPosition = transform.position;
            isPositionSaved = true;
        }

        initialZ = transform.position.z;
        
        timer = 0f;
        won = false; 
    }

    void OnMouseDown()
    {
        if (Camera.main == null) return;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (Camera.main == null) return;
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        
        curPosition.z = initialZ; 
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        if (touchingDropBox && Dropbox != null) SnapTo(Dropbox);
        else if (touchingDropBox1 && Dropbox1 != null) SnapTo(Dropbox1);
        else if (touchingDropBox2 && Dropbox2 != null) SnapTo(Dropbox2);
        else if (touchingDropBox3 && Dropbox3 != null) SnapTo(Dropbox3);
        else if (touchingDropBox4 && Dropbox4 != null) SnapTo(Dropbox4);
    }

    void SnapTo(GameObject targetBox)
    {
        Vector3 targetPos = targetBox.transform.position;
        targetPos.z = targetBox.transform.position.z - 1f; 
        transform.position = targetPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SetTouchingState(other.gameObject, true);
    }

    void OnTriggerExit2D(Collider2D other)
    {  
        SetTouchingState(other.gameObject, false);
    }

    void SetTouchingState(GameObject go, bool state)
    {
        if (go == Dropbox) touchingDropBox = state;
        else if (go == Dropbox1) touchingDropBox1 = state;
        else if (go == Dropbox2) touchingDropBox2 = state;
        else if (go == Dropbox3) touchingDropBox3 = state;
        else if (go == Dropbox4) touchingDropBox4 = state;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (SceneManager.GetActiveScene().name != "SampleScene 1" && SceneManager.GetActiveScene().name != "SampleScene" && SceneManager.GetActiveScene().name != "PutthemBack" && SceneManager.GetActiveScene().name != "thanks for playing")
        {
           Destroy(gameObject);
        }
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "PutthemBack")
        {
            timer += Time.deltaTime; 
            
            if (timer >= 5f)
            {
                if (Vector2.Distance(transform.position, originalPosition) < 0.1f)
                {
                    Debug.Log(gameObject.name + " WON");
                    won = true;
                }
                else
                {
                    Debug.Log(gameObject.name + " lost");
                    won = false;
                }
                if (timer >= 7f)
                {
                    // SYSTEM FIX: Clear the static state so the tracking works next time the game runs
                    isPositionSaved = false; 
                    
                    SceneManager.LoadScene("thanks for playing");
                    Destroy(gameObject); 
                    enabled = false;
                }
            }
        }
    }
}
