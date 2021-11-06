using UnityEngine;

public class HelperBot
{
    public Vector3 GeneratePoint(float x, float z)
    {
        return new Vector3(Random.Range(-x, x), 0, Random.Range(-z, z));
    }
}