using System;
using UnityEngine;

enum AxisType
{
    Vertical,
    Horizontal
}

public class Rotation : MonoBehaviour
{
    [SerializeField] private float normalAxisValue;
    [SerializeField] private float maxAxisValue;
    [SerializeField] private AxisType axisType;
    [SerializeField] private float lastAngle;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        ApplyAxis(0);
    }

    public void ApplyAxis(float value)
    {
        var angle = normalAxisValue + maxAxisValue * value;
        var delta = angle - lastAngle;
        lastAngle = angle;

        switch (axisType)
        {
            case AxisType.Vertical:
                _transform.Rotate(delta, 0, 0);
                break;
            case AxisType.Horizontal:
                _transform.Rotate(0, delta, 0);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}