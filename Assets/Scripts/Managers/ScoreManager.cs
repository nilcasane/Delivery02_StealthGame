using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public static int HighScore {  get; private set; }
    [SerializeField]
    public static int LastScore { get; private set; }

    public static Action<float, float> OnScoreUpdated;

    private void OnEnable()
    {
        OnScoreUpdated += UpdateScore;
    }
    
    private void OnDisable()
    {
        OnScoreUpdated -= UpdateScore;
    }
    
    public void UpdateScore(float Time, float Distance)
    {
        LastScore = CalculateScore(Time, Distance);
        if (LastScore > HighScore)
        {
            HighScore = LastScore;
        }
    }

    private int CalculateScore(float Time, float Distance)
    {
        return Math.Max(0, Mathf.FloorToInt(2000 - (Time + Distance)));
    }
}
