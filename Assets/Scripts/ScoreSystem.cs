using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int playerScore;
    public static ScoreSystem instance;

    public static Action<int> OnScoreUpdated;

    private void Awake()
    {
        if (ScoreSystem.instance == null)
            ScoreSystem.instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        CoinScript.OnCoinCollected += UpdateScore;
    }

    private void OnDisable()
    {
        CoinScript.OnCoinCollected -= UpdateScore;
    }

    private void UpdateScore(CoinScript coin)
    {
        playerScore += coin.coinValue;
        OnScoreUpdated?.Invoke(playerScore);
    }

    public float GetScore()
    {
        return playerScore;
    }
}
