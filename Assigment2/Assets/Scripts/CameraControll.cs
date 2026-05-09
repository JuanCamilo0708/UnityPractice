using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField]
    private Transform _player1;
    [SerializeField]
    private Transform _player2;
    void Update()
    {
        Vector3 midpoint = (_player1.position + _player2.position) / 2;
        transform.position = new Vector3(midpoint.x, midpoint.y, transform.position.z);
    }
}
