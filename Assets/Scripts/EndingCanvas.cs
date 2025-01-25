using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EndingCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private float maxScore;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    void Start()
    {
        if (ScoreSystem.instance != null)
        {
            finalScoreText.text = "Score: " + ScoreSystem.instance.GetScore().ToString();

            if (ScoreSystem.instance.GetScore() == maxScore)
            {
                winPanel.SetActive(true);
                losePanel.SetActive(false);
            }
            else
            {
                winPanel.SetActive(false);
                losePanel.SetActive(true);
            }
        }
        else
        {
            finalScoreText.text = "Score: 0";
        }
    }
}