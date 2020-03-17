using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D enemyCollider)
  {

      if (enemyCollider.GetComponent<Enemy>())
      {
          Enemy enemy = enemyCollider.GetComponent<Enemy>();
          FindObjectOfType<PlayerStatus>().SubtractFromScore(enemy.GetKillPoints());
          Destroy(enemy.gameObject);
          FindObjectOfType<LevelController>().RemoveFromEnemyCount();
      } else if (enemyCollider.GetComponent<GoodStuff>())
      {
        Destroy(enemyCollider.GetComponent<GoodStuff>().gameObject);
        FindObjectOfType<LevelController>().RemoveFromEnemyCount();
      }
  }
}
