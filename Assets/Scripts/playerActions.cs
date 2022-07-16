using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class playerActions : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerInput playerInput;
    private InputActions playerInputActions;
    private Camera cam;
    private Vector3 mousePos;
    
    [SerializeField]
    private Transform weapon;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    private Animator animator;

    [SerializeField]
    private float timeBulletStart = 0.25f;

    private bool canShot = true;
    private bool hitted = false;
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
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
        playerRigidbody.AddForce(new Vector3(inputVector.x, 0 , inputVector.y) * (speed), ForceMode.Force);
    }
    
    public void FixedUpdate()
    {
        addForce(playerInputActions.Player.Movement.ReadValue<Vector2>());

        /*
        Ray ray = cam.ScreenPointToRay(playerInputActions.Player.MousePos.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            mousePos = raycastHit.point;
        }

        Vector3 lookDir = mousePos - playerRigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.z) * Mathf.Rad2Deg - 90f;
        weapon.rotation = Quaternion.Euler(0f,0f,angle);
        */

    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        addForce(context.ReadValue<Vector2>());
    }
    
    private void Mouse_performed(InputAction.CallbackContext context)
    {
        //mousePos = cam.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    private IEnumerator shoot()
    {
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("Attack", false);
        hitted = false;
        yield return new WaitForSeconds(timeBulletStart - 0.25f);
        canShot = true;
    }

    public void mouse_tap(InputAction.CallbackContext context)
    {
        if (context.performed && canShot)
        {
            canShot = false;
            animator.SetBool("Attack", true);
            StartCoroutine(shoot());
            //Instantiate(bullet, shotPoint.position, weapon.rotation);
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Enemy") && animator.GetBool("Attack") && !hitted)
        {
            hitted = true;
            col.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}