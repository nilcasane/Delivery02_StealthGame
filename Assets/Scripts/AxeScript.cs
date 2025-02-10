using System;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public static Action OnAxePicked;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnAxePicked?.Invoke();
        }
    }
}
