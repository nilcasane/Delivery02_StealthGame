using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    public float RotationSpeed = 5f;
    [SerializeField]
    public float RotationAngle = 45f;
    public float AngleIncrement = 1f;
    private float CurrentAngle;
    private float _startAngle;
    private float _endAngle;
    public bool AscendingAngle = true;

    [SerializeField]
    public float PatrolStayTime = 2f;
    [SerializeField]
    public float IdleWaitTime = 1f;

    public Transform Player;
    public Rigidbody2D RigidBody;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        RigidBody = GetComponent<Rigidbody2D>();
        CurrentAngle = RigidBody.rotation;
        _startAngle = CurrentAngle - RotationAngle;
        _endAngle = CurrentAngle + RotationAngle;
    }
    public float NextRotationAngle()
    {
        if (AscendingAngle)
        {
            if (CurrentAngle == _endAngle)
            {
                AscendingAngle = false;
                CurrentAngle--;
            }
            else
            {
                CurrentAngle++;
            }
        }
        else
        {
            if (CurrentAngle == _startAngle)
            {
                AscendingAngle = true;
                CurrentAngle++;
            }
            else
            {
                CurrentAngle--;
            }
        }
        return CurrentAngle;
    }
}
