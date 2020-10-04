using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLabel : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;
    void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
        GlobalVariables.instance.OnScoreChanged += SetScore;
        SetScore(GlobalVariables.instance.Score);
    }


    public void SetScore(int score)
    {
        ScoreText.text = score.ToString();
    }

    private void OnDestroy()
    {
        GlobalVariables.instance.OnScoreChanged -= SetScore;
    }
}
