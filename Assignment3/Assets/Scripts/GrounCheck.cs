using UnityEngine;

public class GrounCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int collisionCount = 0;
    public bool IsGrounded { get { return collisionCount > 0; } 
}

    private void OnTriggerEnter(Collider other)
    {
        ++collisionCount;
    }
     private void OnTriggerExit(Collider other)
    {
        --collisionCount;
    }
}
