using System;
using UnityEngine;

public class CameraKiller : MonoBehaviour
{
    public static Action OnPlayerKilled;
    private void Start()
    {
        OnPlayerKilled?.Invoke();
    }
}
