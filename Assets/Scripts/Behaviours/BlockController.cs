using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlockController : MonoBehaviour
{
    private static readonly int DEFAULT_HEALTH;
    private static readonly int HEALTHY_SPRITE_INDEX = 0;
    private static readonly int CRACKED_SPRITE_INDEX = 1;

    // Number of hits before destroying
    [SerializeField] private int health = DEFAULT_HEALTH;
    [SerializeField] private Sprite[] sprites;

    private int initialHealth;

    private void Start()
    {
        initialHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
        if (health <= (initialHealth / 2))
            SetCrackedSprite();
    }

    // Code for destoying
    private void TakeDamage()
    {
        health--;
        if (health <= 0)
            Destroy(gameObject);
    }

    private void SetCrackedSprite()
    {
        Debug.Log("Set cracked sprite");
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[CRACKED_SPRITE_INDEX];
    }   
}
