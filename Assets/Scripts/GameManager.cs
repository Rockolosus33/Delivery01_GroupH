using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void OnEnter()
    {
        Play();
    }

    void OnExit()
    {
        Application.Quit();
    }
}
