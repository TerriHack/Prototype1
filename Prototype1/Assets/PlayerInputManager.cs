using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    private PlayerInputs controls;
    private PlayerInputs.GroundMovementActions groundMovement;

    private Vector2 horizontalInput;
    private void Awake()
    {
        controls = new PlayerInputs();
        groundMovement = controls.GroundMovement;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        playerController.ReceiveInput(horizontalInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    
    private void OnDisnable()
    {
        controls.Disable();
    }
}
