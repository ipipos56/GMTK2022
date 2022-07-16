using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CreateDots : MonoBehaviour
{
    
    private Quaternion rotation;
    [SerializeField] private GameObject dot;
    [SerializeField] private Transform zeroPoint;
    [SerializeField] private float radius;
    [SerializeField] private int number;

    private void Awake()
    {
        rotation = Quaternion.Euler(90, 0, 0);
    }

    void Start()
    {
        Vector3 pos = gameObject.transform.position;
        switch (number)
        {
            case 1:
                Instantiate(dot, gameObject.transform.position, rotation);
                break;
            case 2:
                pos.z += radius / 2;
                pos.x += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z -= radius;
                pos.x -= radius;
                Instantiate(dot, pos, rotation);
                break;
            case 3:
                Instantiate(dot, pos, rotation);
                pos.z += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z -= radius;
                Instantiate(dot, pos, rotation);
                break;
            case 4:
                pos.z += radius / 2;
                pos.x += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z -= radius;
                pos.x -= radius;
                Instantiate(dot, pos, rotation);
                
                pos = gameObject.transform.position;
                pos.z -= radius / 2;
                pos.x += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z += radius;
                pos.x -= radius;
                Instantiate(dot, pos, rotation);
                break;
            case 5:
                Instantiate(dot, pos, rotation);
                pos.z += radius / 2;
                pos.x += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z -= radius;
                pos.x -= radius;
                Instantiate(dot, pos, rotation);
                
                pos = gameObject.transform.position;
                pos.z -= radius / 2;
                pos.x += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z += radius;
                pos.x -= radius;
                Instantiate(dot, pos, rotation);
                break;
            case 6:
                pos.x += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z -= radius;
                Instantiate(dot, pos, rotation);
                pos = gameObject.transform.position;
                pos.x -= radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.z -= radius;
                Instantiate(dot, pos, rotation);
                break;
            default:
                Instantiate(dot, gameObject.transform.position, rotation);
                break;
        }
    }
    
}
