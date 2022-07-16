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
        switch (number)
        {
            case 1:
                Instantiate(dot, gameObject.transform.position, rotation);
                break;
            case 3:
                Vector3 pos = gameObject.transform.position;
                Instantiate(dot, pos, rotation);
                pos.x += radius / 2;
                Instantiate(dot, pos, rotation);
                pos.x -= radius;
                Instantiate(dot, pos, rotation);
                break;
            default:
                Instantiate(dot, gameObject.transform.position, rotation);
                break;
        }
    }
    
}
