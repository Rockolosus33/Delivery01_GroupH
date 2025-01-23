using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundDetector;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [SerializeField] private Transform wallDetector;
    [SerializeField] private float wallCheckRadius = 0.1f;
    [SerializeField] private float slidingSpeed;

    private bool hasTouchedWall = false;

    Rigidbody2D playerRigidbody;
    private int jumpCount = 1;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            jumpCount = 1;
        }

        if (IsOnWall())
        {
            Vector2 velocity = playerRigidbody.linearVelocity;
            velocity.y = -slidingSpeed;
            playerRigidbody.linearVelocity = velocity;

            if (!hasTouchedWall)
            {
                jumpCount++;
                hasTouchedWall = true;
            }
        }
        else
        {
            hasTouchedWall = false;
        }
    }

    public bool IsOnWall()
    {
        var colliders = Physics2D.OverlapCircleAll(wallDetector.position, wallCheckRadius, groundLayerMask);
        return colliders.Length > 0;
    }

    void OnJump()
    {
        if (jumpCount > 0) 
        {
            SetGravity();
            Vector2 vel = new Vector2(playerRigidbody.linearVelocity.x, jumpForce);
            playerRigidbody.linearVelocity = vel;

            jumpCount--;
        }
    }

    private void SetGravity()
    {
        playerRigidbody.gravityScale = 1f;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(wallDetector.position, wallCheckRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundDetector.position, groundCheckRadius);
    }

    private bool IsGrounded()
    {
        var colliders = Physics2D.OverlapCircleAll(groundDetector.position, groundCheckRadius, groundLayerMask);
        return colliders.Length > 0;
    }
}
