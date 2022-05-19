using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private MouseLook mouseLook;
    
    private PlayerInputs controls;
    private PlayerInputs.GroundMovementActions groundMovement;

    private Vector2 horizontalInput;
    private Vector2 mouseInput;

    private bool isAttacking;
    private void Awake()
    {
        controls = new PlayerInputs();
        groundMovement = controls.GroundMovement;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        playerController.ReceiveInput(horizontalInput, isAttacking);
        
        mouseLook.ReceiveInput(mouseInput);
        
        isAttacking = groundMovement.Attack.triggered;
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    
    private void OnDisable()
    {
        controls.Disable();
    }
}
