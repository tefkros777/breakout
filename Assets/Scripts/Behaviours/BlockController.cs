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
    private Vector2 initialPosition;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        initialHealth = health;
        initialPosition = transform.position;
        
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        GameOverScript.OnResetRequest += Reset;
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
        {
            // Destroy(gameObject);
            gameObject.SetActive(false); // Just disable, dont destroy for replay purposes
        }
    }

    private void SetCrackedSprite()
    {
        Debug.Log("Set cracked sprite");
        spriteRenderer.sprite = sprites[CRACKED_SPRITE_INDEX];
    }

    private void Reset()
    {
        Debug.Log("Resetting block"); 

        // Re-enable
        gameObject.SetActive(true);

        // Reset Position
        transform.position = initialPosition; // it never moves so perhaps we dont need it
        
        // Reset health
        health = initialHealth;

        // Reset sprite to healthy
        spriteRenderer.sprite = sprites[HEALTHY_SPRITE_INDEX];
    }
}
