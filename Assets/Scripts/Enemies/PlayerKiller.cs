using System;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Killed");
            GameplayManager.OnPlayerLose?.Invoke();
        }
    }
}
