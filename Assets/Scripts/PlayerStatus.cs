using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float score = 1000;
    [SerializeField] Text scoreText;
    bool notYetPlayed = true;
    void Start()
    {
        score = Mathf.Round(score / PlayerPrefsController.GetMasterDifficulty());
        scoreText = FindObjectOfType<ScoreBoard>().GetComponent<Text>();
        UpdateScore();
    }
    public void AddToScore(float points)
    {
        score += points;
        UpdateScore();
    }
  
    public void SubtractFromScore(float points)
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
