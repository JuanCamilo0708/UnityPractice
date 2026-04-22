using UnityEngine;

public class RotationPin : MonoBehaviour
{
    [SerializeField]
    private int _speed;
    [SerializeField]
    private float _mult;
    void Update()
    {
        transform.Rotate(0f, 0f, _speed * Time.deltaTime);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball  = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.AddMult(_mult);
        }

    }
}
