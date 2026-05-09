using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public bool IsGrounded => _numberOfCollisions > 0;
    [SerializeField]
    private int _numberOfCollisions = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _numberOfCollisions++;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _numberOfCollisions--;
    }
}
