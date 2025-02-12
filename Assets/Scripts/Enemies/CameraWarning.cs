using System;
using UnityEngine;

public class CameraWarning : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RobotController.OnCameraWarning?.Invoke();
        }
    }

}
