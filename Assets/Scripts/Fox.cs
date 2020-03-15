using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            if (otherObject.GetComponent<Fence>())
            {
                Debug.Log("I will jump");
                GetComponent<Animator>().SetTrigger("jumpTrigger");
            }
            else
            {
                Debug.Log("I am going to attack");
                GetComponent<Enemy>().Attack(otherObject);
            }

        }
    }
}
