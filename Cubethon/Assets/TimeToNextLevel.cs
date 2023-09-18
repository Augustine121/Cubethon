using UnityEngine;
using UnityEngine.UI;

public class TimeToNextLevel : MonoBehaviour
{
    public Text timeText;
    public float countdown;
    
    void Update()
    {
        timeText.text = "NEXT LEVEL BEGINS IN: " + (int)(countdown -= Time.deltaTime);
    }
}
