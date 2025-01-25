using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    private Animator playerAnimator;
    private AudioSource deathSFX;
    [SerializeField] private AudioClip dieSound;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("timeToDie", TimeManager.instance.GetTime());
        playerAnimator.SetBool("isDying", false);
        deathSFX = GetComponent<AudioSource>();
    }

    void Update()
    {
        playerAnimator.SetFloat("timeToDie", TimeManager.instance.GetTime());

        if (TimeManager.instance.GetTime() >= 5f && !playerAnimator.GetBool("isDying"))
        {
            playerAnimator.SetBool("isDying", false);
        }
    }

    public void StopDying()
    {
        deathSFX.PlayOneShot(dieSound);
        playerAnimator.SetBool("isDying", true);
    }

    public void GoToEndScene()
    {
        SceneManager.LoadScene("Ending");
    }
}