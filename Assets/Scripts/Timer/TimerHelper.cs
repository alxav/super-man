using System;
using UnityEngine;

public class TimerHelper
{
    /// <summary>
    /// Возвращет строку формата MM:SS
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Format(float value)
    {
        var min = Mathf.FloorToInt(value / 60);
        var sec = Mathf.FloorToInt(value - (min * 60));

        TimeSpan ts = new TimeSpan(0, min, sec);
        return ts.ToString(@"mm\:ss");
    }
}