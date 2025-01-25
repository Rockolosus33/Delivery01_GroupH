using System;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] private float incrementJumpValue = 0.2f;
    private Animator animator;
    private Collider2D skullCollider;
    private AudioSource skullSFX;

    public static Action<float> OnPowerUpCollected;

    private void Start()
    {
        skullCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        skullSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            skullSFX.Play();
            animator.SetTrigger("skullCollected");
            skullCollider.enabled = false;
            OnPowerUpCollected?.Invoke(incrementJumpValue);
        }
    }

    private void DestroySkull()
    {
        Destroy(gameObject, skullSFX.clip.length);
    }
}
