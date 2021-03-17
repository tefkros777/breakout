using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private static readonly int DEFAULT_HEALTH;

    // Number of hits before destroying
    [SerializeField] private int health = DEFAULT_HEALTH;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage();
    }

    // Code for destoying
    private void takeDamage()
    {
        health--;

        if (health <= 0)
            Destroy(gameObject);
    }
}
