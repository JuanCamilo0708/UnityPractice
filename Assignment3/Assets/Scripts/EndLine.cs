using UnityEngine;

public class EndLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider != null)
        {
            GameManager.Instance.StopTimer();
        }
    }
}
