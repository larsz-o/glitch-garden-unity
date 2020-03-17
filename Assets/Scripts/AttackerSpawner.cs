using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawning = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] GameObject[] enemyPrefabs;
    int index;
   void Start()
    {
        if (spawning)
        {
            StartCoroutine(MakeAttackers());
        }
    }
    IEnumerator MakeAttackers()
    {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
    }
    private void Spawn()
    {
        GameObject newEnemy = Instantiate(enemyPrefabs[index], transform.position, transform.rotation) as GameObject;
        newEnemy.transform.parent = transform;
        FindObjectOfType<LevelController>().AddToEnemyCount();
    }
    private void SpawnAttacker()
    {
        int length = enemyPrefabs.Length;
        index = Random.Range(0, length);
        Spawn();
    }
    public void TurnOffSpawner()
    {
        spawning = false;
        Debug.Log("spawing off");
    }

}
