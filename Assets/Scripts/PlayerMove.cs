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

    public bool IsMoving { get; private set; }
    public static float Distance { get; private set; }
    public static Action<int> OnDistanceUpdated;

    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private Vector2 _direction;
    private Vector3 _actualPos, _lastPos;
    private float _lastAngle;


    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        Distance = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = _rigidbody.transform;
        _lastPos = _transform.position;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        _rigidbody.linearVelocity = _direction * MoveSpeed;
        IsMoving = _direction.magnitude > 0.01f;

        _actualPos = _transform.position;
        if (_actualPos != _lastPos)
        {
            Distance += Vector3.Distance(_actualPos, _lastPos);
            _lastPos = _actualPos;
            OnDistanceUpdated?.Invoke((int) Distance);
        }
    }

    void OnMove(InputValue value)
    {
        _direction = value.Get<Vector2>();
        _lastAngle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        UpdateSprite();
    }
    void UpdateSprite()
    {
        
        _animator.SetFloat("MoveX", _direction.x);
        _animator.SetFloat("MoveY", _direction.y);
        _animator.SetFloat("Speed", _direction.sqrMagnitude);

        if (_direction.x < 0) _spriteRenderer.flipX = true;
        else _spriteRenderer.flipX = false;

        if (!IsMoving)
        {
            StartCoroutine(UpdateIdleAngleAfterDelay());
        }
    }

    private System.Collections.IEnumerator UpdateIdleAngleAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        // Angle update
        _animator.SetFloat("LastAngle", _lastAngle);
    }
}
