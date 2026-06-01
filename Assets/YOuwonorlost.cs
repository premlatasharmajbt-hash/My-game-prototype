using UnityEngine;
using TMPro;
public class YOuwonorlost : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemDrag.timer >= 10)
        {
          if (ItemDrag.won == true)
          {
            Text.text = "YOU WON";
          }
          else if (ItemDrag.won == false)
          {
            Text.text = "You LOST";
          }      
        }
    }
}
