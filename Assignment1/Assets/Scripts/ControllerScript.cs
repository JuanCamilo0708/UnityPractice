using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _dropItemPrefab = null;
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private Vector2 _maxRange = Vector2.zero;
    private Vector2 _startingPoint = Vector2.zero;

    private void Awake()
    {
        _startingPoint = transform.position;
    }
    void Update()
    {
        Vector2 endPos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            endPos.y += _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            endPos.y -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            endPos.x -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            endPos.x += _speed * Time.deltaTime;
        }
        endPos.x = Mathf.Clamp(endPos.x, _startingPoint.x - _maxRange.x, _startingPoint.x + _maxRange.x);
        endPos.y = Mathf.Clamp(endPos.y, _startingPoint.y - _maxRange.y, _startingPoint.y + _maxRange.y);
        transform.position = endPos;
        if (Input.GetKeyDown(KeyCode.Space))
        {

            float rotate = Random.Range(0, 360);
            Quaternion rotation = Quaternion.Euler(0, 0, rotate);
            Instantiate(_dropItemPrefab, transform.position, rotation);

        }
    }
}
