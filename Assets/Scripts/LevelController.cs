using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int enemyCount = 0;
    bool gameTimerDone = false;
    bool keepCounting = true;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitTime = 5f;
    [SerializeField] AudioClip loseSound;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        Time.timeScale = 1f;
    }
    private void CountEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        enemyCount = enemies.Length;
    }
    public void HandleLose()
    {
        loseLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position);
        FindObjectOfType<DefenderSpawner>().EndDefenderPlacement();
        Time.timeScale = 0f;
        FindObjectOfType<BankDisplay>().DepleteAccount();
        StopSpawning();
    }
    IEnumerator HandleWin()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<LoadLevel>().LoadNextScene();
    }

    public void StopSpawning()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopMySpawning();
        }
    }
    public void TimerLevelFinished()
    {
        gameTimerDone = true;
        StopSpawning();
    }
    private void Update()
    {
        if (keepCounting)
        {
            CountEnemies();
            if (gameTimerDone && enemyCount <= 0)
            {
                Debug.Log("Win!");
                StartCoroutine(HandleWin());
                keepCounting = false;
            }
        }

    }
}
