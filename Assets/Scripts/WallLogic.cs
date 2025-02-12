using UnityEngine;

public class WallLogic : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        ButtonScript.OnButtonPressed += Destroy;
    }
    private void OnDisable()
    {
        ButtonScript.OnButtonPressed -= Destroy;

    }
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
