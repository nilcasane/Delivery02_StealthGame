using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]
    private float MoveSpeed = 5.0f;

    public bool IsMoving => _isMoving;
    private bool _isMoving;
    private bool _isSneaking;

    Rigidbody2D _rigidbody;
    Transform _transform;
    Vector2 Direction;
    Vector3 actualPos, lastPos;
    [SerializeField]
    private float Distance = 0;

    public static Action<int> OnDistanceUpdated;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = _rigidbody.transform;
        lastPos = _transform.position;
    }

    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        _rigidbody.linearVelocity = Direction * (_isSneaking ? MoveSpeed / 2 : MoveSpeed);
        _isMoving = Direction.magnitude > 0.01f;

        actualPos = _transform.position;
        if (actualPos != lastPos)
        {
            Distance += Vector3.Distance(actualPos, lastPos);
            lastPos = actualPos;
            OnDistanceUpdated?.Invoke((int) Distance);
        }
    }

    void OnHorizontalMove(InputValue value)
    {
        Direction.x = value.Get<float>();
    }
    void OnVerticalMove(InputValue value)
    {
        Direction.y = value.Get<float>();
    }
}
