using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    private Text _label; 

    void Start()
    {
        _label = GetComponent<Text>();
    }

    private void OnEnable()
    {
        TimeManager.OnTimeUpdated += UpdateTimeText;
    }

    private void OnDisable()
    {
        TimeManager.OnTimeUpdated -= UpdateTimeText;
    }

    private void UpdateTimeText(int Time)
    {
        _label.text = "Time: " + Time + " sec.";
    }
}
