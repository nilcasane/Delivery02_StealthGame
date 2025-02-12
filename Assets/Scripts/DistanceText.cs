using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour
{
    private Text _label;
    
    void Start()
    {
        _label = GetComponent<Text>();
    }
    private void OnEnable()
    {
        PlayerMove.OnDistanceUpdated += UpdateDistanceText;
    }
    
    private void OnDisable()
    {
        PlayerMove.OnDistanceUpdated -= UpdateDistanceText;
    }
    
    private void UpdateDistanceText(int Distance)
    {
        _label.text = "Distance: " + Distance + " units";
    }
}
