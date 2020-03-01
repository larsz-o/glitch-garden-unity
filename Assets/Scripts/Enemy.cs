using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0f, 5f)]
    float movementSpeed = 1f;

    void Start()
    {
    }
    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

        public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
}
