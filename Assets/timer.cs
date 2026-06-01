using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = ItemDrag.timer.ToString("F2"); 
    }
}
