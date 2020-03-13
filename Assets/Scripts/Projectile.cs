using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 50;

    void Update()
    {
      transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
void OnTriggerEnter2D(Collider2D otherCollider)
  { 
      var health = otherCollider.GetComponent<Health>();
      var enemy = otherCollider.GetComponent<Enemy>();
      if(health && enemy){
        health.DealDamage(damage);
      }
      Destroy(gameObject);
  }
}
