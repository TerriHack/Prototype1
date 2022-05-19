using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Animator swordAnim;
    [SerializeField] private float speed = 11f;

    private Vector2 horizontalInput;
    
    private bool isAttacking;

    public bool isGrounded;


    private void Update()
    {
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        playerRb.AddForce(horizontalVelocity,ForceMode.Force);

        if (isAttacking)
        {
            swordAnim.SetBool("isAttacking",true);
            isAttacking = false;
        }
        else
        {
            swordAnim.SetBool("isAttacking",false);
        }
    }

    public void ReceiveInput(Vector2 _horizontalInput, bool _isAttacking)
    {
        horizontalInput = _horizontalInput;
        print(horizontalInput);

        isAttacking = _isAttacking;
    }
}
