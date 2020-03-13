using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawning = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Enemy enemyPrefab;
    IEnumerator Start()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawn();
        }
    }
    private void Spawn()
    {
       Enemy newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation) as Enemy;
       newEnemy.transform.parent = transform;
    }
 
}
