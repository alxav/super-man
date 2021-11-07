using System;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{
    [SerializeField] private CubeVariable cube;

    [Header("Area")] 
    [SerializeField] private float x; 
    [SerializeField] private float z;
    
    private Transform _transform;
    private Helper helper;
    
    
    private void Awake()
    {
        _transform = transform;
        helper = new Helper();
        Cube.Attack += Attack;
    }
    
    void Start()
    {
        Generate();
    }
    
    private void Attack(bool flag)
    {
        Create(cube.Data);
    }
    
    private void Generate()
    {
        var data = cube.Data;

        for (int i = 0; i < data.Count; i++)
        {
            Create(data);
        }
    }

    private void Create(DataCube data)
    {
        var clone = Instantiate(data.Prefab, _transform);
        clone.transform.position = helper.GeneratePoint(x, z) + Vector3.up * clone.transform.localScale.y / 2;
        clone.Constructor(data.Layers, data.Force);
    }

    private void OnDestroy()
    {
        Cube.Attack -= Attack;
    }
}
