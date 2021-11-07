using System;
using UnityEngine;

[CreateAssetMenu]
public class CubeVariable: ScriptableObject
{
    [SerializeField] private DataCube data;
    
    public DataCube Data => data;
}

[Serializable]
public class DataCube
{
    [SerializeField] private Cube prefab;
    [SerializeField] private int count;
    [SerializeField] private LayerMask layers;
    [SerializeField] private float force;

    public Cube Prefab => prefab;
    public int Count => count;

    public LayerMask Layers => layers;

    public float Force => force;
}
