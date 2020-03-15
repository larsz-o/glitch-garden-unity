using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodStuff : MonoBehaviour
{
  [SerializeField] int points;
  [SerializeField] GameObject sprite;

  private void OnTriggerEnter2D(Collider2D otherCollider)
  {
      GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            otherObject.GetComponent<Health>().AddHealth(points);

        }
    }
  }
