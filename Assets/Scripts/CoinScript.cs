using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Animator animator;
    public int coinValue = 5;

    public static Action<CoinScript> OnCoinCollected;
    private AudioSource coinSFX;

    private void Start()
    {
        animator = GetComponent<Animator>();
        coinSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("coinCollected");
            coinSFX.Play();
        }
    }

    private void DestroyCoin()
    {
        OnCoinCollected?.Invoke(this);
        Destroy(gameObject);
    }
}
