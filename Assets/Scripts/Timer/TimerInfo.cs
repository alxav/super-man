using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerInfo : MonoBehaviour
{
    [SerializeField] private floatVariable time;

    private Text text;
    private TimerHelper timerHelper;

    private void Awake()
    {
        text = GetComponent<Text>();
        timerHelper = new TimerHelper();
    }

    private void OnEnable()
    {
        SetValue(time.Value);
        time.Listeners += SetValue;
    }

    private void SetValue(float value)
    {
        if (text)
            text.text = timerHelper.Format(value);
    }
}