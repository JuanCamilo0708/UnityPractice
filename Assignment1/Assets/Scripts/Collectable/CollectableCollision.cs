using UnityEngine;

public class CollectableCollision : MonoBehaviour
{
    [SerializeField]
    private Vector2 _maxRange = Vector2.zero;
    [SerializeField]
    private float _xSpeed = 2f;
    private void OnTriggerEnter2D(Collider2D collider)
    {
      
        Ball ball = collider.gameObject.GetComponent<Ball>();
        if (ball == null)
        {
            return;
        }
        GameManager.Instance.AddScore((int)(50 * ball.Mult));
        CollectableScript.Instance.Generate();
        Destroy(gameObject);
    }
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x = pos.x + _xSpeed * Time.deltaTime;
        if (pos.x >= _maxRange.x || pos.x <= -_maxRange.x )
        {
            _xSpeed = -_xSpeed;
        }
        transform.position = pos;
    }


}
