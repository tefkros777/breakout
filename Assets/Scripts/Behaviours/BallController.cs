using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{

    [SerializeField] private float movingSpeed;


    private static readonly float GRAVITY_OFF = 0;
    private bool firstCollisionFlag = true;

    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    private Collider2D ballCollider;
    private Collider2D dockCollider;
    private BoxCollider2D[] blockColliders;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ballCollider = gameObject.GetComponent<CircleCollider2D>();
        dockCollider = FindObjectOfType<CapsuleCollider2D>();
        blockColliders = FindObjectsOfType<BoxCollider2D>();
    }
    
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION");

        // On the first collision with the dock, turn gravity off
        if (firstCollisionFlag)
        {
            rb.gravityScale = GRAVITY_OFF;
            firstCollisionFlag = false;
        }

        var newDirection = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        // Set new direction
        rb.velocity = newDirection * movingSpeed;

    }

    private void Bounce(Rigidbody2D objectToBounce)
    {
        Debug.Log("TRIGGER ENTERED");

        var vIn = objectToBounce.velocity;
        vIn.y *= -1f * movingSpeed;
        objectToBounce.velocity = vIn;

        //Vector2.Reflect(rigidbody.velocity, collision.GetContact(0).normal);


    }
}
