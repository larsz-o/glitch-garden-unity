using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    [SerializeField] int score = 1000;
    [SerializeField] Text scoreText;
    bool notYetPlayed = true;
    void Start()
    {

        scoreText = FindObjectOfType<ScoreBoard>().GetComponent<Text>();
        UpdateScore();
    }
    public void AddToScore(int points)
    {
        score += points;
        UpdateScore();
    }
  
    public void SubtractFromScore(int points)
    {
        score -= points;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
        if (score <= 0 && notYetPlayed)
        {
            FindObjectOfType<LevelController>().HandleLose();
            notYetPlayed = false;
        }
    }
}
