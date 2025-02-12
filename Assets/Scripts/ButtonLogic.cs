using System;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    public static Action OnButtonPressed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnButtonPressed?.Invoke();
        }
    }
}
