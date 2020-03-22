using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 500;
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
                Destroy(gameObject);
            }
            
        }
    }
    public void AddHealth(int points)
    {
        health += points;
        var animator = GetComponent<Animator>();
        if (animator)
        {
            animator.SetTrigger("healthAdd");
        }
        
    }
}
