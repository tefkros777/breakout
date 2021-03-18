using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomSpriteSelector : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    // Randomly render one sprite from the sprite array set in the editor
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

}
