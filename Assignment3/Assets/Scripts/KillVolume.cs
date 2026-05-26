using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            PLayerController player = other.gameObject.GetComponent<PLayerController>();
            if (player != null)
            {
                player.Respawn();
            }
        }
    }
}
