using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
            if(otherCollider.GetComponent<GoodStuff>())
            {
                otherCollider.GetComponent<GoodStuff>().SetMovementSpeed(2f);
               
            }
    }
}