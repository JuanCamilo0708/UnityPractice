using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D _rb;
    [SerializeField]
    private Animator _animator = null;
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _jumpForce = 15f;
    [SerializeField]
    private float _desiredMoveSpeed = 0.0f;
    
    private float _facingDirection = 0f;
    [SerializeField]
    private GroundCheck _groundCheck;
    private PlayerInput _playerInput;
    [SerializeField]
    private bool _isJumping = false;
    [SerializeField]
    private bool _isFalling = false;
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
        if (_rb.linearVelocityY < -0.1f && !_groundCheck.IsGrounded)
        {
            _isFalling = true;
            _isJumping = false;
        }
        else if (_isFalling && _groundCheck.IsGrounded && _rb.linearVelocityY < 0.1f)
        {
            _isFalling = false;
        }

    }
    private void FixedUpdate()
    {
        _rb.linearVelocityX = _desiredMoveSpeed;
        if (Mathf.Abs(_rb.linearVelocityX) > 0.1f)
        {
            _facingDirection = (_desiredMoveSpeed) > 0.0f ? 0.0f : 1.0f;
        }
        _animator.SetFloat("Speed", Mathf.Abs(_rb.linearVelocityX));
        _animator.SetFloat("Direction", _facingDirection);
        _animator.SetBool("Jump", _isJumping);
        _animator.SetBool("Fall", _isFalling);


    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (_groundCheck.IsGrounded && _rb.linearVelocityY < 0.1f)
            _rb.linearVelocityY = _jumpForce;
        _isJumping = true;
    }
}
