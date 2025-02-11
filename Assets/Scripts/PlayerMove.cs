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

    [SerializeField]
    private float Distance = 0;

    public static Action<int> OnDistanceUpdated;

    SpriteRenderer _spriteRenderer;
    public Sprite UpSprite, DownSprite, SideSprite, DiagonalUpSprite, DiagonalDownSprite;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = _rigidbody.transform;
        lastPos = _transform.position;
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
        UpdateSprite();
    }
    void UpdateSprite()
    {
        // Diagonal move
        if (Direction.x != 0 && Direction.y != 0)
        {
            // Up diagonal
            if (Direction.y > 0)
            {
                _spriteRenderer.sprite = DiagonalUpSprite;
                // Flip if necessary
                if (Direction.x < 0) _spriteRenderer.flipX = true;
                else if (Direction.x > 0) _spriteRenderer.flipX = false;
            }
            // Down diagonal
            else
            {
                _spriteRenderer.sprite = DiagonalDownSprite;
                // Flip if necessary
                if (Direction.x < 0) _spriteRenderer.flipX = true;
                else if (Direction.x > 0) _spriteRenderer.flipX = false;
            }
        }
        else if (Direction.x != 0)
        {
            _spriteRenderer.sprite = SideSprite;
            // Flip if necessary
            if (Direction.x < 0) _spriteRenderer.flipX = true;
            else if (Direction.x > 0) _spriteRenderer.flipX = false;
        }
        else if (Direction.y > 0) _spriteRenderer.sprite = UpSprite;
        else if (Direction.y < 0) _spriteRenderer.sprite = DownSprite;
    }
}
