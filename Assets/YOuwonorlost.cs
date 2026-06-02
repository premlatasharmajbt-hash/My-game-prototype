using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class YOuwonorlost : MonoBehaviour
{
    public TextMeshProUGUI Text;

    void Start()
    {
     Text.text = "";  
    }
    void Update()
    {
      if (GameObject.Find("Item1") == null || GameObject.Find("Item2") == null)
      {
        ItemDrag.timer += Time.deltaTime;
        if (ItemDrag.timer >= 7f)
        {
          ItemDrag.isPositionSaved = false; 
          SceneManager.LoadScene("thanks for playing");
        }
      }
      if (ItemDrag.timer >= 5f)
      {
        if (ItemDrag.won == true)
        {
          if (ItemDrag1.won == true)
          {
            Text.text = "You won!";
            if (GameObject.Find("Item1") != null)
            {
              Destroy(GameObject.Find("Item1"));
            }
            if (GameObject.Find("Item2") != null)
            {
              Destroy(GameObject.Find("Item2"));
            }
          }
          else
          {
            Text.text = "You lost!";
            if (GameObject.Find("Item1") != null)
            {
              Destroy(GameObject.Find("Item1"));
            }
            if (GameObject.Find("Item2") != null)
            {
              Destroy(GameObject.Find("Item2"));
            }
          }
        }
        else
        {
          Text.text = "You lost!";
          if (GameObject.Find("Item1") != null)
            {
              Destroy(GameObject.Find("Item1"));
            }
            if (GameObject.Find("Item2") != null)
            {
              Destroy(GameObject.Find("Item2"));
            }
        }    
      }
    }
    public static void waitfor7()
    {
      
    }
}
