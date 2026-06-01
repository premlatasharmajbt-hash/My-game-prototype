using UnityEngine;
using TMPro;

public class YOuwonorlost : MonoBehaviour
{
    public TextMeshProUGUI Text;

    void Start()
    {
     Text.text = "";  
    }
    void Update()
    {
      if (ItemDrag.timer >= 10f)
      {
        if (ItemDrag.won == true)
        {
          Text.text = "You won!";
        }
        else
        {
          Text.text = "You lost!";
        }    
      }
    }
}
