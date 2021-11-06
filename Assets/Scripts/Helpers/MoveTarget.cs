using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offsetTarget;
    
    private Transform _transform;
    
    
    void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        _transform.position = target.position + offsetTarget;
    }
}
