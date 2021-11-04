using UnityEngine;

[CreateAssetMenu]
public class floatVariable : ScriptableObject
{
    public delegate void OnEvent(float value);
    
    [SerializeField] private float value;

    private event OnEvent listeners;
    
    public float Value
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