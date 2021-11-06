using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BotVariable : ScriptableObject
{
    [SerializeField] private List<BotData> list;

    public BotData Get(EnumBot type) => list.Find((bot) => bot.Type == type);
}


[Serializable]
public class BotData
{
    public string name;
    [SerializeField] private EnumBot type;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int count;
    [Range(1, 10)] [SerializeField] private float speed;
    
    public EnumBot Type
    {
        get => type;
    }
    
    public GameObject Prefab
    {
        get => prefab;
    }
    
    public int Count
    {
        get => count;
    }
    public float Speed
    {
        get => speed;
    }
}
