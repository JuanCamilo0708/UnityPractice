using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    private int _scoreValue = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null && collision.gameObject.CompareTag("DropItem"))
        {
            GameManager.Instance.AddScore(_scoreValue);
            Destroy(collision.gameObject);
        }
    }
}

