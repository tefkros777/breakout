using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{

    [SerializeField] private float speed;
    
    private static readonly float GRAVITY_OFF = 0;

    private Rigidbody2D rigidbody;
    private Collider2D ballCollider;
    private Collider2D dockCollider;
    private BoxCollider2D[] blockColliders;


    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        ballCollider = gameObject.GetComponent<CircleCollider2D>();
        dockCollider = FindObjectOfType<CapsuleCollider2D>();
        blockColliders = FindObjectsOfType<BoxCollider2D>();
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION");

        // Set gravity off on first collision with the dock
        rigidbody.gravityScale = GRAVITY_OFF;
        
        // At the point of contact velocity is 0, that is the problem

        // Now just reflect
        Vector2.Reflect(rigidbody.velocity, collision.GetContact(0).normal);

    }
}
