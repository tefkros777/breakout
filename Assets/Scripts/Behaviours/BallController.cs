using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CommandProcessor))]
public class BallController : MonoBehaviour, IEntity
{

    [SerializeField] private float movingSpeed;

    private static readonly float GRAVITY_OFF = 0;
    private bool firstCollisionFlag = true;
    private Vector2 lastVelocity;

    private Rigidbody2D rb;
    private CommandProcessor mCommandProcessor;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mCommandProcessor = gameObject.GetComponent<CommandProcessor>();
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

        mCommandProcessor.ExecuteCommand(new BounceCommand(this, lastVelocity, collision.contacts[0], movingSpeed));
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
