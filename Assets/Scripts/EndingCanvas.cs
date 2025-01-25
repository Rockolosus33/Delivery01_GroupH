using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EndingCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    void Start()
    {
        if (ScoreSystem.instance != null)
        {
            finalScoreText.text = "Score: " + ScoreSystem.instance.GetScore().ToString();

            if (TimeManager.instance.GetTime() > 30f)
            {
                finalTimeText.text = "Total time: " + 30 + " seconds";
            }
            else
            {
                finalTimeText.text = "Total time: " + TimeManager.instance.GetTime().ToString("F2") + " seconds";
            }

            if (ScoreSystem.instance.GetScore() == ScoreSystem.instance.GetMaxScore())
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
            finalTimeText.text = "Total time: 0 seconds";
        }
    }
}