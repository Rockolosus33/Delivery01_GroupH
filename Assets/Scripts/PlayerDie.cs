using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("timeToDie", TimeManager.instance.GetTime());
        playerAnimator.SetBool("isDying", false);
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
        playerAnimator.SetBool("isDying", true);
    }

    public void GoToEndScene()
    {
        SceneManager.LoadScene("Ending");
    }
}