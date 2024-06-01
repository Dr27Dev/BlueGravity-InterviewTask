using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Rigidbody2D _rb;
    private CharacterInput _characterInput;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _characterInput = GetComponent<CharacterInput>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 movementAmount = _characterInput.MovementAxis * (_movementSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(movementAmount + _rb.position);
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _characterInput.MovementAxis.sqrMagnitude);
        _animator.SetFloat("Movement X", _characterInput.MovementAxis.x);
        _animator.SetFloat("Movement Y", _characterInput.MovementAxis.y);
    }
}
