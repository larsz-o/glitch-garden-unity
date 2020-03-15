using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodStuff : MonoBehaviour
{
  [SerializeField] int points;
    float movementSpeed = 1.5f;
  void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }
  private void OnTriggerEnter2D(Collider2D otherCollider)
  {
      Debug.Log("Hello");
      GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            SetMovementSpeed(0f);
            otherObject.GetComponent<Health>().AddHealth(points);
            Destroy(gameObject);

        }
    }
    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
  }
