using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerActions : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private PlayerInput playerInput;
    private InputActions playerInputActions;

    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new InputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Movement.performed += Movement_performed;

    }

    private void addForce(Vector2 inputVector)
    {
        playerRigidbody.MovePosition(playerRigidbody.position + (inputVector * speed));
    }

    void Update()
    {
        addForce(playerInputActions.Player.Movement.ReadValue<Vector2>());
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        addForce(context.ReadValue<Vector2>());
    }
}