using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CommandProcessor))]
public class BallController : MonoBehaviour, IEntity
{

    [SerializeField] private float movingSpeed;

    private Vector2 lastVelocity;

    private Rigidbody2D rb;
    private CommandProcessor mCommandProcessor;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mCommandProcessor = gameObject.GetComponent<CommandProcessor>();
    }

    private void Start()
    {
        mCommandProcessor.ExecuteCommand(new ShootCommand(this, Time.timeSinceLevelLoad, 1.5f, movingSpeed));
    }

    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION");
        mCommandProcessor.ExecuteCommand(new BounceCommand(this, Time.timeSinceLevelLoad, lastVelocity, collision.contacts[0], movingSpeed));
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
