﻿using System.Collections;
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
                GetComponent<Animator>().SetTrigger("jumpTrigger");
            }
            else
            {
                GetComponent<Enemy>().Attack(otherObject);
            }

        }
    }
}
