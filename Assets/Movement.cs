using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public InputActionReference move;
    public InputActionReference jump;

    private Vector2 _moveDirection;
    private bool _isGrounded;
    private int _jumpCount; 

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }

    private void OnEnable()
    {
        jump.action.performed += Jump;
    }

    private void OnDisable()
    {
        jump.action.performed -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_jumpCount < 2) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            _jumpCount++; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _jumpCount = 0; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}