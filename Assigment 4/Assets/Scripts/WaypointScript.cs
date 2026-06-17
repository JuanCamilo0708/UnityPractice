using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    [SerializeField]
    private float _gizmoRadius = 0.5f;
    private Color _gizmoColor = Color.red;
    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawSphere(transform.position, _gizmoRadius);
    }
}
