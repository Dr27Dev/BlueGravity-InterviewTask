using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Animator[] _animators;
    
    private Rigidbody2D _rb;
    private CharacterInput _characterInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _characterInput = GetComponent<CharacterInput>();
        _animators[0] = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 movementAmount = _characterInput.MovementAxis * (_movementSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(movementAmount + _rb.position);
    }

    private void Update()
    {
        foreach (var animator in _animators)
        {
            if (animator != null)
            {
                animator.SetFloat("Speed", _characterInput.MovementAxis.sqrMagnitude);
                animator.SetFloat("Movement X", _characterInput.MovementAxis.x);
                animator.SetFloat("Movement Y", _characterInput.MovementAxis.y);
            }
        }
    }
}
