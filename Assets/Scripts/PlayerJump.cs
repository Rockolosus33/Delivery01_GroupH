using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Transform groundDetector;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [SerializeField] private Transform wallDetector;
    [SerializeField] private float wallCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayerMask;

    public float JumpHeight;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;
    public float PressTimeToMaxJump;
    public float WallSlideSpeed = 1;
    public float gravityWhenFalling = 1.2f;
    public float initialJumpForce = 2f;

    private Rigidbody2D _rigidbody;
    private float _lastVelocityY;
    private float _jumpStartedTime;
    private int jumpCount = 2;
    private float originalGravityValue = 9.81f;
    private bool hasTouchedWall = false;
    private Animator playerAnimator;

    public static Action<bool> OnWallTouched;
    private AudioSource jumpSFX;

    private void Start()
    {
        jumpSFX = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            jumpCount = 2;
            playerAnimator.SetBool("canRunJumAnimation", false);
        }

        if (IsPeakReached()) TweakGravity();

        if (IsOnWall())
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x,
            Mathf.Max(_rigidbody.linearVelocity.y, -WallSlideSpeed));

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

        OnWallTouched?.Invoke(IsOnWall());
    }

    public bool IsOnWall()
    {
        var colliders = Physics2D.OverlapCircleAll(wallDetector.position, wallCheckRadius, groundLayerMask);
        return colliders.Length > 0;
    }

    public void OnJumpStarted()
    {
        jumpCount--;

        if (jumpCount > 0) 
        {
            // meter audio
            jumpSFX.Play();
            if (IsGrounded())
            {
                playerAnimator.SetBool("canRunJumAnimation", true);
            }

            SetGravity();
            var vel = new Vector2(_rigidbody.linearVelocity.x, GetJumpForce());
            _rigidbody.linearVelocity = vel;
            _jumpStartedTime = Time.time;
        }
    }

    public void OnJumpFinished()
    {
        float fractionOfTimePressed = 1 / Mathf.Clamp01((Time.time - _jumpStartedTime) / PressTimeToMaxJump);
        _rigidbody.gravityScale *= fractionOfTimePressed;
    }

    private bool IsPeakReached()
    {
        bool reached = ((_lastVelocityY * _rigidbody.linearVelocity.y) < 0);
        _lastVelocityY = _rigidbody.linearVelocity.y;

        return reached;
    }

    private void SetGravity()
    {
        var grav = initialJumpForce * JumpHeight * (SpeedHorizontal * SpeedHorizontal) / (DistanceToMaxHeight * DistanceToMaxHeight);
        _rigidbody.gravityScale = grav / originalGravityValue;
    }

    private void TweakGravity()
    {
        _rigidbody.gravityScale *= gravityWhenFalling;
    }

    private float GetJumpForce()
    {
        return initialJumpForce * JumpHeight * SpeedHorizontal / DistanceToMaxHeight;
    }

    private bool IsGrounded()
    {
        var colliders = Physics2D.OverlapCircleAll(groundDetector.position, groundCheckRadius, groundLayerMask);
        return colliders.Length > 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(wallDetector.position, wallCheckRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundDetector.position, groundCheckRadius);
    }
}
