using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Kills : MonoBehaviour
{
    [SerializeField] private integerVariable kills;
    private Text text;
    private string info = "KILLS: ";

    void Awake()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        SetValue(kills.Value);
        kills.Listeners += SetValue;
    }

    private void SetValue(int value)
    {
        if (text)
            text.text = info + value;
    }

    // todo временно, для тестов. Убрать
    public void TestKill()
    {
        kills.Value += 1;
    }

    private void OnDestroy()
    {
        kills.Value = 0;
    }
}