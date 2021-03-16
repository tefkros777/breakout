using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour, IEntity
{

    [SerializeField] private float movingSpeed;

    private static readonly float GRAVITY_OFF = 0;
    private bool firstCollisionFlag = true;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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

        Bounce(collision.contacts[0]);
    }

    private void Bounce(ContactPoint2D collisionPoint)
    {
        var newDirection = Vector2.Reflect(lastVelocity.normalized, collisionPoint.normal);
        // Set new direction
        rb.velocity = newDirection * movingSpeed;
    }

    // IEntity Properties
    public Vector2 GetVelocity()
    {
        return rb.velocity;
    }
    public void SetVelocity(Vector2 vel)
    {
        rb.velocity = vel;
    }
}
