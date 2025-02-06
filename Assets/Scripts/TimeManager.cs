using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float Timer {  get; private set; }
    public static Action<int> OnTimeUpdated;

    void Start()
    {
        
    }

    void Update()
    {
        Timer += Time.deltaTime;
        OnTimeUpdated?.Invoke((int) Timer);
    }
}
