using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var botScript = other.GetComponent<Bot>();
        if (botScript)
            botScript.Kill();
    }
}
