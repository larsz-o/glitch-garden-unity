﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
      
    }
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount == 0)
        {
            return false;
        } else {
            return true;
        }
    }
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }
}
