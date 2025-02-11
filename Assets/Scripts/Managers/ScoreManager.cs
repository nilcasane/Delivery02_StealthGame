using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public static int HighScore {  get; private set; }
    [SerializeField]
    public static int LastScore { get; private set; }

    public static Action<float, float> OnScoreUpdated;

    public static ScoreManager Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        Debug.Log(LastScore);
        if (LastScore > HighScore)
        {
            HighScore = LastScore;
            Debug.Log(HighScore);
        }
    }
    private int CalculateScore(float Time, float Distance)
    {
        //score = 10000 - (time + distance);
        return Mathf.FloorToInt(10000 - (Time + Distance));
    }
}
