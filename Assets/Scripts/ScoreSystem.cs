using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int playerScore;

    public static Action<int> OnScoreUpdated;

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
}
