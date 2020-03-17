using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int enemyCount = 0;
     public void AddToEnemyCount()
    {
        enemyCount++;
    }
    public void RemoveFromEnemyCount()
    {
       
        enemyCount--;
    }
    void Update()
    {
        bool gameTimerDone = FindObjectOfType<GameTimer>().GetGameTimer();
        if (gameTimerDone)
        {
            FindObjectOfType<AttackerSpawner>().TurnOffSpawner();
            if(enemyCount <= 0)
            {
                Debug.Log("End level now");
            }
        }
    }
}
