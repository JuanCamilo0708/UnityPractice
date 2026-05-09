using UnityEngine;

public class ResetController : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Transform _position;
    [SerializeField]
    private GameObject _player1;
    [SerializeField]
    private GameObject _player2;
    [SerializeField]
    private Vector3 _initialPosition1;
    [SerializeField]
    private Vector3 _initialPosition2;
    [SerializeField]
    private Collectable[] _collectables;
    [SerializeField]
    private TotemSwitch[] _totemSwitches;
    private string _sceneName;
    void Awake()
    {
        _initialPosition1 = _player1.transform.position;
        _initialPosition2 = _player2.transform.position;
        _sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

    }
    private void Start()
    {
        _collectables = FindObjectsByType<Collectable>();
        _totemSwitches = FindObjectsByType<TotemSwitch>();
    }
    void Update()
    {
        transform.position = new Vector3(_position.position.x, -10, transform.position.z);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {

            _player1.transform.position = _initialPosition1;
            _player2.transform.position = _initialPosition2;
            foreach (var collectable in _collectables)
            {
                collectable.ResetCollectable();

            }
            foreach (var totemSwitch in _totemSwitches)
            {
                totemSwitch.Reset();
            }
            if (_sceneName == "Level1")
                GameManager.Instance.Reset();

        }
    }
}
