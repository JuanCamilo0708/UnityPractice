using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform _shoulder;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _turnSpeed = 1f;
    [SerializeField]
    private float _maxPinch = 75f;
    [SerializeField]
    private float _minPinch = -75f;
    private Rigidbody _rb;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _lookAction;
    private Vector3 _moveVelocity = Vector3.zero;
    private Vector3 _moveRotation = Vector3.zero;
    private float _pitchRotation = 0f;
    private int _initialFrameSkip = 2;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move;
        _lookAction = _playerInput.Player.Look;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        _moveAction.Enable();
        _lookAction.Enable();

    }
    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();

    }
    private void Update()
    {
        if(_initialFrameSkip > 0)
        {
            _initialFrameSkip--;
            return;

        }
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        Vector2 lookInput = _lookAction.ReadValue<Vector2>();
        Vector3 fwd = transform.forward;
        Vector3 right = transform.right;
        _moveVelocity = (fwd * moveInput.y + right * moveInput.x) * _speed;
        _moveRotation.y = lookInput.x * _turnSpeed;

        _pitchRotation = Mathf.Clamp(_pitchRotation + lookInput.y, _minPinch, _maxPinch);
    }
    private void FixedUpdate()
    {
        _moveVelocity.y = _rb.linearVelocity.y;
        _rb.linearVelocity = _moveVelocity;
        _rb.angularVelocity = _moveRotation;
        _shoulder.localRotation = Quaternion.Euler(_pitchRotation, 0f, 0f);
    }
}


