using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard instance;
    [SerializeField] TextMeshProUGUI scoreText;
    int score;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scoreText.text = "START";
    }
    public void IncreaseScore(int scoreToAdd)
    {
        score += scoreToAdd;
        Debug.Log("Current Score: "+ score);
        scoreText.text = score.ToString();
    }
}
