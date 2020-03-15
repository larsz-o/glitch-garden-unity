using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 500;
    // Start is called before the first frame update
    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if(GetComponent<Enemy>())
            {
                Enemy self = GetComponent<Enemy>();
                int points = self.GetKillPoints();
                FindObjectOfType<PlayerStatus>().AddToScore(points);
                Debug.Log("added points:" + points);
            }
            Destroy(gameObject);
        }
    }
    public void AddHealth(int points)
    {
        health += points;
    }
}
