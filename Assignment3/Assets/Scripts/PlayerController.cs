using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PLayerController : MonoBehaviour
{
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private Transform shoulder;
    [SerializeField]
    private GrounCheck groundCheck;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float turnSpeed = 1f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private bool invertY = false;
    [SerializeField]
    private float maxPitch = 80f;
    [SerializeField]
    private float minPitch = -80f;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private Vector3 moveVelocity = Vector3.zero;
    private Vector3 moveRotation = Vector3.zero;
    [SerializeField]
    private Vector3 lastGroundedPosition = Vector3.zero;
    private float pitchRotation = 0f;
    private int initalFrameSkip = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        moveAction = playerInput.Player.Move;
        lookAction = playerInput.Player.Look;
        jumpAction = playerInput.Player.Jump;
        jumpAction.performed += OnJump;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start()
    {
        gameObject.transform.position = startPosition.position;
    }
    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if(initalFrameSkip> 0)
        {
            initalFrameSkip--;
            return;
        }
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        Vector3 fwd = transform.forward;
        Vector3 right = transform.right;
        moveVelocity = (fwd * moveInput.y + right * moveInput.x) * speed;

        moveRotation.y = lookInput.x * turnSpeed;
        if (!invertY)
        {
            lookInput.y *= -1;
        }
        pitchRotation = Mathf.Clamp(pitchRotation + lookInput.y, minPitch, maxPitch);

        if(groundCheck.IsGrounded && rb.linearVelocity.y < 0.1)
        {
            lastGroundedPosition = transform.position;
        }
    }
    private void FixedUpdate()
    {
        moveVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = moveVelocity;
        rb.angularVelocity = moveRotation;
        shoulder.localRotation = Quaternion.Euler(pitchRotation, 0f, 0f);
    }
    private void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (rb.linearVelocity.y < 0.1f && groundCheck.IsGrounded)
        {
            Vector3 jumpVelocity = rb.linearVelocity;
            jumpVelocity.y = jumpForce;
            rb.linearVelocity = jumpVelocity;
        }
    }
    public void Respawn()
    {
        CheckPoint checkPoint = CheckPointManager.Instance.GetCheckPoint();
        if (checkPoint != null) { 
            lastGroundedPosition = checkPoint.transform.position;
        }
        rb.linearVelocity = Vector3.zero;
        lastGroundedPosition.y += 1.0f;
        transform.position = lastGroundedPosition;
    }
}
