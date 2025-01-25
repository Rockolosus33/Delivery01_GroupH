using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EndingCanvas : MonoBehaviour
{
    [SerializeField] private Text finalScoreText;
    [SerializeField] private float maxScore;

    void Awake()
    {
        finalScoreText.text = ScoreSystem.instance.GetScore().ToString();

        if (ScoreSystem.instance.GetScore() == maxScore)
        {

        }
        else
        {

        }
    }
}