using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private int maxScore;
    [SerializeField] private int playerScore;
    [SerializeField] private int lastScore;

    public static ScoreSystem instance;
    public static Action<int> OnScoreUpdated;

    private void Awake()
    {
        if (ScoreSystem.instance == null)
        {
            ScoreSystem.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerScore = 0;
        lastScore = playerScore;
    }

    private void Update()
    {
        if (playerScore == maxScore)
        {
            SceneManager.LoadScene("Ending");
        }
    }

    private void OnEnable()
    {
        CoinScript.OnCoinCollected += UpdateScore;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        CoinScript.OnCoinCollected -= UpdateScore;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Ending" || scene.name == SceneManager.GetActiveScene().name)
        {
            ResetScore();
        }
    }

    private void UpdateScore(CoinScript coin)
    {
        playerScore += coin.coinValue;
        OnScoreUpdated?.Invoke(playerScore);
    }

    public float GetScore()
    {
        return lastScore;
    }

    public float GetMaxScore()
    {
        return maxScore;
    }

    public void ResetScore()
    {
        lastScore = playerScore;
        playerScore = 0;
        OnScoreUpdated?.Invoke(playerScore);
    }
}