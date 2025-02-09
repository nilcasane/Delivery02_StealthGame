using UnityEngine;

public class WallScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        ButtonScript.OnButtonPressed += OpenDoor;
    }
    private void OnDisable()
    {
        ButtonScript.OnButtonPressed -= OpenDoor;

    }
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OpenDoor()
    {
        _spriteRenderer.enabled = false;
    }
}
