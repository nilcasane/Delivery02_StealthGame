﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMove _movement;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMove>();
    }

    void Update()
    {
        //_animator.SetBool("Walk", _movement.IsMoving);
    }
}
