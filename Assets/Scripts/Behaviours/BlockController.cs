using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private int health;

    private void Awake()
    {
        health = 3;
    }

    void Update()
    {
        
    }

    // Code for destoying

    private void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage();
    }

    private void takeDamage()
    {
        health--;

        if (health <= 0)
            Destroy(gameObject);
    }

    // Number of lives

}
