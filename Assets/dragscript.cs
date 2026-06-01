using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour
{
    public Vector3 originalPosition;
    public float timeToMove = 0.5f;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Coroutine returnRoutine;
    private bool timeExpired = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        
        timeExpired = false;
        
        returnRoutine = StartCoroutine(MoveAfterDelay());

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (timeExpired) return;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        timeExpired = false;
    }

    IEnumerator MoveAfterDelay()
    {
        float timer = 0f;
        while (timer < timeToMove)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        timeExpired = true; 
    }
}
