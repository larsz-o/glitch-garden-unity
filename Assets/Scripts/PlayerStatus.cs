using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    int score = 5000;
    [SerializeField] Text scoreText;
    int lives = 3;
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
        if (score <= 0)
        {
            FindObjectOfType<LoadLevel>().LoseLevel();
        }
    }
}
