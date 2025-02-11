using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private Text _label;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _label = GetComponent<Text>();
    }

    private void OnEnable()
    {
        ScoreManager.OnScoreUpdated += UpdateScoreText;
    }
    private void OnDisable()
    {
        ScoreManager.OnScoreUpdated -= UpdateScoreText;
    }
    private void UpdateScoreText(int Score)
    {
        _label.text = "Score: " + Score + " points.";
    }

    
}
