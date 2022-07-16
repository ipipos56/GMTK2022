using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerActions : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private PlayerInput playerInput;
    private InputActions playerInputActions;
    private Camera cam;
    private Vector2 mousePos;
    
    [SerializeField]
    private Transform weapon;
    [SerializeField] private float speed = 5f;
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;

        playerInputActions = new InputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Movement.performed += Movement_performed;
        playerInputActions.Player.MousePos.performed += Mouse_performed;

    }

    private bool sign_to_bool(float value)
    {
        if (value > 0.1)
            return true;
        return false;
    }

    private void addForce(Vector2 inputVector)
    {
        playerRigidbody.MovePosition(playerRigidbody.position + (inputVector * (speed)));
    }
    
    public void FixedUpdate()
    {
        addForce(playerInputActions.Player.Movement.ReadValue<Vector2>());

        mousePos = cam.ScreenToWorldPoint(playerInputActions.Player.MousePos.ReadValue<Vector2>());

        Vector2 lookDir = mousePos - playerRigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        weapon.rotation = Quaternion.Euler(0f,0f,angle);
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        addForce(context.ReadValue<Vector2>());
    }
    
    private void Mouse_performed(InputAction.CallbackContext context)
    {
        mousePos = cam.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}