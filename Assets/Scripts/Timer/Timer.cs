using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private floatVariable time;

    private EnumGameState state;
    private float startValue;
    void Awake()
    {
        startValue = time.Value;
        GameState.Get += value => state = value;
    }

    private void Update()
    {

        if (state != EnumGameState.Game) return;

        time.Value -= Time.deltaTime;

        if (time.Value <= 0)
        {
            GameState.Instance.Finish();
        }

    }

    private void OnDestroy()
    {
        time.Value = startValue;
    }
}
