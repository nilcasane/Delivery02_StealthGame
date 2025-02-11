using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float Timer {  get; private set; }
    public static Action<int> OnTimeUpdated;

    void Start()
    {
        Timer = 0.0f;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        OnTimeUpdated?.Invoke((int) Timer);
    }

    public static void Reset()
    {
        Timer = 0.0f;
    }
}
