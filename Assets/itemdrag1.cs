using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemDrag1 : MonoBehaviour
{
    private static Vector3 originalPosition;
    private static bool isPositionSaved = false;

    // References the exact same safety lock variable to stay synchronized
    private static bool isSceneLoading = false;

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
    
    // Unique timer and win state completely isolated to this item
    private static float Timer = 0f; 
    public static bool won;
    
    private float initialZ;

    void Start()
    {
        if (!isPositionSaved)
        {
            originalPosition = transform.position;
            isPositionSaved = true;
        }

        initialZ = transform.position.z;
        Timer = 0f;
        won = false; 
        isSceneLoading = false; 
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
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "SampleScene")
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (currentSceneName != "SampleScene 1" && currentSceneName != "SampleScene" && currentSceneName != "PutthemBack" && currentSceneName != "thanks for playing")
        {
           Destroy(gameObject);
           return;
        }

        if (currentSceneName == "PutthemBack")
        {
            Timer += Time.deltaTime; 
            
            if (Timer >= 5f)
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

                if (Timer >= 7f)
                {
                    isPositionSaved = false; 

                    // SAFETY CHECK: Only change the scene if the other script hasn't done it yet
                    if (!isSceneLoading)
                    {
                        isSceneLoading = true; // Lock the door
                        SceneManager.LoadScene("thanks for playing");
                    }
                    
                    Destroy(gameObject); 
                }
            }
        }
    }
}
