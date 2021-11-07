using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public static event Action<bool> Attack; 
    
    private Rigidbody rb;
    private NavMeshAgent navMeshAgent;
    private LayerMask layers;
    private float force;
    private bool isAttack;
    private Transform _transform;
    
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        _transform = transform;
    }
    
    public void Constructor(LayerMask layers, float force)
    {
        this.force = force;
        this.layers = layers;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAttack) return;
        var currentLayer = (1 << other.gameObject.layer);
        if (currentLayer == layers)
        {
            isAttack = true;

            rb.isKinematic = false;
            rb.useGravity = true;
            
            var vectorForce = _transform.position - other.transform.position;

            // Добавил вектор up, чтобы кубики красивее летели
            rb.AddForce((vectorForce.normalized + Vector3.up) * force); 
            
            navMeshAgent.enabled = false;

            Attack?.Invoke(true);

            StartCoroutine(DestroyCoroutine());
        }
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
