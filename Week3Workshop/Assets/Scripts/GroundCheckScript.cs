using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    public bool IsGrounded => _numberOfCollisions > 0;
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
