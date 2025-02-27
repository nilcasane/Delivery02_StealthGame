using System;
using UnityEngine;

public class AxeLogic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameplayManager.OnPlayerWin?.Invoke();
        }
    }
}
