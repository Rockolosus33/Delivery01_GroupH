using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float timer;

    private bool stopCounting = false;

    void Start()
    {
        timer = 0f;
        stopCounting = false;

        playerAnimator.SetFloat("timeToDie", timer);
        playerAnimator.SetBool("isDying", false);
    }

    void Update()
    {
        if (timer < 30f)
        {
            timer += Time.deltaTime;
            playerAnimator.SetFloat("timeToDie", timer);
        }
        else if (!playerAnimator.GetBool("isDying") && !stopCounting)
        {
            playerAnimator.SetBool("isDying", true);
            stopCounting = true;
        }
    }
}