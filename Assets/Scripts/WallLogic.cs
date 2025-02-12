using UnityEngine;

public class WallLogic : MonoBehaviour
{
    private void OnEnable()
    {
        ButtonLogic.OnButtonPressed += Destroy;
    }

    private void OnDisable()
    {
        ButtonLogic.OnButtonPressed -= Destroy;

    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
