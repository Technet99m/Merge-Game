using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Manager<ScoreManager>
{
    [SerializeField] int scorePerItem;
    Text scoreText;
    int score;

    private void Start()
    {
        
        scoreText = GetComponent<Text>();
        scoreText.text = "0";
    }

    public void AddScore()
    {
        score += scorePerItem;
        scoreText.text = score.ToString();
    }
}
