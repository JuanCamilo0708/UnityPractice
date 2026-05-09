using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Vector3 _initialPosition;
    [SerializeField]
    private bool _isPlayer1Collectable;
    void Awake()
    {
        _initialPosition = transform.position;
    }
    
    public void Collect()
    {
        gameObject.SetActive(false);
    }

    public void ResetCollectable()
    {
        transform.position = _initialPosition;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isPlayer1Collectable && collision.GetComponent<Player1Controller>()) { 
            GameManager.Instance.AddDiamond();
            Collect();
        }
        if (!_isPlayer1Collectable && collision.GetComponent<Player2Controller>())
        {
            GameManager.Instance.AddEmerald();
            Collect();
        }
    }
}
