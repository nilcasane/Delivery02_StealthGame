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

    Rigidbody2D _rigidbody;
    Transform _transform;
    Vector2 Direction;
    Vector3 actualPos, lastPos;
    float _lastAngle;


    [SerializeField]
    public static float Distance { get; private set; }

    public static Action<int> OnDistanceUpdated;

    private Animator _animator;

    SpriteRenderer _spriteRenderer;
    public Sprite UpSprite, DownSprite, SideSprite, DiagonalUpSprite, DiagonalDownSprite;

    void Start()
    {
        Distance = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = _rigidbody.transform;
        lastPos = _transform.position;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        _rigidbody.linearVelocity = Direction * MoveSpeed;
        _isMoving = Direction.magnitude > 0.01f;

        actualPos = _transform.position;
        if (actualPos != lastPos)
        {
            Distance += Vector3.Distance(actualPos, lastPos);
            lastPos = actualPos;
            OnDistanceUpdated?.Invoke((int) Distance);
        }
    }

    void OnMove(InputValue value)
    {
        Direction = value.Get<Vector2>();
        if (Direction.sqrMagnitude > 0)
        {
            _lastAngle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        }
        UpdateSprite();
    }
    void UpdateSprite()
    {
        
        _animator.SetFloat("MoveX", Direction.x);
        _animator.SetFloat("MoveY", Direction.y);
        _animator.SetFloat("Speed", Direction.sqrMagnitude);

        if (Direction.x < 0) _spriteRenderer.flipX = true;
        else _spriteRenderer.flipX = false;

        if (!_isMoving)
        {
            StartCoroutine(UpdateIdleAngleAfterDelay());
        }
    }

    // Corrutina para retrasar la actualización del ángulo de idle
    private System.Collections.IEnumerator UpdateIdleAngleAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        // Angle update
        _animator.SetFloat("LastAngle", _lastAngle);
    }
}
