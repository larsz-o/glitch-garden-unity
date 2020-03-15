using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStatus : MonoBehaviour
{
    int score = 5000;
    [SerializeField] Text scoreText;
    int lives = 3;
    [SerializeField] GameObject lifeIcon;
    void Start()
    {

        scoreText = FindObjectOfType<ScoreBoard>().GetComponent<Text>();
        UpdateScore();
        DisplayLives();
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
    public void DisplayLives()
    {
        for (var i = 0; i < lives; i++)
        {
            GameObject life = Instantiate(lifeIcon, transform.position, Quaternion.identity) as GameObject;
            life.transform.parent = transform;
        }
    }
    private void addLives(int amount)
    {
        lives += amount;
        DisplayLives();
    }
    private void RemoveLives(int amount)
    {
        lives -= amount;
        DisplayLives();
    }
}
