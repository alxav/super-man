using System;
using UnityEngine;

[CreateAssetMenu]
public class integerVariable : ScriptableObject
{
    public delegate void OnEvent(int value);
    
    [SerializeField] private int value;

    private event OnEvent listeners;
    
    public int Value
    {
        get => value;
        set
        {
            this.value = value;
            Raise();
        }
    }

    public event OnEvent Listeners
    {
        add
        {
            listeners -= value;
            listeners += value;
        }
        remove => listeners -= value;
    }

    private void Raise()
    {
        listeners?.Invoke(value);
    }
    
}