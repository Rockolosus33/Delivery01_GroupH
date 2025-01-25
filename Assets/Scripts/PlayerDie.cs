using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    private Animator playerAnimator;
    private AudioSource deathSFX;

    [SerializeField] private AudioClip dieSound;

    public static bool playerHasDied;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("timeToDie", TimeManager.instance.GetTime());
        playerAnimator.SetBool("isDying", false);
        deathSFX = GetComponent<AudioSource>();

        playerHasDied = false;
    }

    void Update()
    {
        playerAnimator.SetFloat("timeToDie", TimeManager.instance.GetTime());

        if (TimeManager.instance.GetTime() >= 30f && !playerAnimator.GetBool("isDying"))
        {
            playerAnimator.SetBool("isDying", false);
            playerHasDied = true;
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