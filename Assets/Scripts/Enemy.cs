using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0f, 5f)]
    float movementSpeed = 1f;
    GameObject currentTarget;
    [SerializeField] int killPoints = 5;

    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        UpdateAnimationState();
    }
     public void Attack(GameObject target)
     {
         GetComponent<Animator>().SetBool("isAttacking", true);
         currentTarget = target;
     }
    public int GetKillPoints()
    {
        return killPoints;
    }
    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
   public void StrikeCurrentTarget(int damage)
   {
       if (!currentTarget)
       {
           return;
       }
       Health health = currentTarget.GetComponent<Health>();
       if (health)
       {
           health.DealDamage(damage);
       }
   }
   private void UpdateAnimationState()
   {
       if (!currentTarget)
       {
           GetComponent<Animator>().SetBool("isAttacking", false);
       }
   }
}
