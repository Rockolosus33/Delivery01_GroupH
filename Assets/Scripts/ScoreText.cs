using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class ScoreText : MonoBehaviour
{
    private Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
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
        Debug.Log("Lamine");
        label.text = score.ToString();
    }
}
