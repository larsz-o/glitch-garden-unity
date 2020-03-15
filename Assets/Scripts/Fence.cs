using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Enemy enemy = otherCollider.GetComponent<Enemy>();
        if (enemy)
        {
            // animate somehow
        }
    }
}