using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class TotemSwitch : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _interactAction;
    [SerializeField]
    private GameObject _door;
    private bool _isInside = false;
    private string _playerTag;
    private void Awake()
    {
        
        _playerInput = new PlayerInput();
        if (CompareTag("Totem"))
        {

            _interactAction = _playerInput.Player1.Interact;
            _playerTag = "Player1";
        }

        else
        {
            _interactAction = _playerInput.Player.Interact;
            _playerTag = "Player2";

        }
                

    }
    private void OnEnable()
    {
        _interactAction.Enable();
    }
    private void OnDisable()
    {
        _interactAction.Disable();
    }
    private void Update()
    {
        if (_isInside && _interactAction.IsPressed())
        {
            _isInside = false;
            _door.SetActive(false);
        }
    }
    public void Reset()
    {
        _door.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {

            _isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {

            _isInside = false;
        }
    }
}
