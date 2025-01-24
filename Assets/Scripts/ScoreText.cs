using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class ScoreText : MonoBehaviour
{
    private Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
    }

    private void Start()
    {
        label.text = "0";
    }

    private void OnEnable()
    {
        ScoreSystem.OnScoreUpdated += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreSystem.OnScoreUpdated -= UpdateScoreText;
    }

    private void UpdateScoreText(int score)
    {
        label.text = score.ToString();
    }
}
