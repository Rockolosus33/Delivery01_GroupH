using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator animator;
    public int coinValue = 5;

    public static Action<CoinScript> OnCoinCollected;

<<<<<<< Updated upstream
=======
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
>>>>>>> Stashed changes

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("coinCollected");
        }
    }

    private void DestroyCoin()
    {
        OnCoinCollected?.Invoke(this);
        Destroy(gameObject);
    }
}
