using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private TimeManager _timeManager;
    private int _score;
    private int _highScore;

    private int _time;

    public static Action<int> OnScoreUpdated;

    public static ScoreManager Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
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

    //score = 10000 - (time + distance);

}
