using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5.0f;

    Rigidbody2D playerRigidbody;
    private float playerHorizontalDir;
    private Vector3 playerScale;
    private Animator playerAnimator;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerScale = this.transform.localScale;
    }

    private void Update()
    {
        playerAnimator.SetFloat("movingState", Mathf.Abs(playerHorizontalDir));
    }

    void FixedUpdate()
    {
        Vector2 velocity = playerRigidbody.linearVelocity;
        velocity.x = playerHorizontalDir * Speed;
        playerRigidbody.linearVelocity = velocity;
    }

    void OnMove(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        playerHorizontalDir = inputVal.x;

        if (playerHorizontalDir < 0)
        {
            playerScale.x = -Mathf.Abs(playerScale.x);
            transform.localScale = playerScale;
        }
        else if (playerHorizontalDir > 0)
        {
            playerScale.x = Mathf.Abs(playerScale.x);
            transform.localScale = playerScale;
        }
    }
}
