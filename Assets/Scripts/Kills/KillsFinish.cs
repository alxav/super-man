using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class KillsFinish : MonoBehaviour
{
    [SerializeField] private integerVariable kills;
    
    private Text text;
    private string info = "KILLS: "; 
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        text.text = info + kills.Value;
    }
}
