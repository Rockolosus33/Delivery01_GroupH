using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5.0f;

    Rigidbody2D playerRigidbody;
    private float playerHorizontalDir;
    private Vector3 playerScale;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerScale = this.transform.localScale;
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
