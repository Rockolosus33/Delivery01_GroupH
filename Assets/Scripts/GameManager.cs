using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

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
        Debug.Log("Exit...");
        Application.Quit();
    }
}
