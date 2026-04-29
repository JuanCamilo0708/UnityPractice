using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _jumpForce = 15f;
    [SerializeField]
    private float _desiredMoveSpeed = 0.0f;
    private float _facingDirection = 0f;
    [SerializeField]
    private GroundCheckScript _groundCheck;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move; 
        _jumpAction = _playerInput.Player.Jump;
        _jumpAction.performed += OnJump;
    }
    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
    }
    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        _desiredMoveSpeed = _moveAction.ReadValue<Vector2>().x * _moveSpeed;



    }
    private void FixedUpdate()
    {
        _rb.linearVelocityX = _desiredMoveSpeed;
        _animator.SetFloat("Speed", Mathf.Abs(_desiredMoveSpeed));
        if(Mathf.Abs(_desiredMoveSpeed)>0.1f)
        {
            _facingDirection = (_desiredMoveSpeed > 0) ? 0f : 1f;
        }
        _animator.SetFloat("Speed", Mathf.Abs(_desiredMoveSpeed));
        _animator.SetFloat("Direction", _facingDirection); 


    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (_groundCheck.IsGrounded&&_rb.linearVelocityY<0.1f)
            _rb.linearVelocityY= _jumpForce;
    }
}
