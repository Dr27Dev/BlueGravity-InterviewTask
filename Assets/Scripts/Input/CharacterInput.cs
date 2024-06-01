using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    private CustomInput _customInput;

    private InputAction _interact;
    private InputAction _pause;
    public Action Input_Interact;
    public Action Input_Pause;
    
    public Vector2 MovementAxis;

    private void Awake() => _customInput = new CustomInput();

    private void Update()
    {
        MovementAxis = _customInput.Player.Movement.ReadValue<Vector2>();
    }

    private void Interact(InputAction.CallbackContext ctx)
    {
        if (Input_Interact != null) Input_Interact.Invoke();
    }

    private void Pause(InputAction.CallbackContext ctx)
    {
        if (Input_Pause != null) Input_Pause.Invoke();
    }

    private void OnEnable()
    {
        _customInput.Enable();
        
        _interact = _customInput.Player.Interact;
        _interact.Enable();
        _interact.performed += Interact;
        
        _pause = _customInput.Player.Pause;
        _pause.Enable();
        _pause.performed += Pause;
        
    }

    private void OnDisable()
    {
        _customInput.Disable();
        _interact.Disable();
        _pause.Disable();
    }

}
