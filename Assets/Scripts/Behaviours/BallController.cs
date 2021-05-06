using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour, IEntity
{

    [SerializeField] private float movingSpeed;

    private Vector2 lastVelocity;
    private bool mFirstLaunch = true;

    private Rigidbody2D rb;
    private CommandProcessor mCommandProcessor;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mCommandProcessor = FindObjectOfType<CommandProcessor>();
        if (mCommandProcessor)
        {
            Debug.Log("BallController - CommandProcessor found");
        }
        else
        {
            Debug.Log("BallController - Cannot find CommandProcessor");
        }
    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION");
        mCommandProcessor.ExecuteCommand(new BounceCommand(this, Time.timeSinceLevelLoad, lastVelocity, collision.contacts[0], movingSpeed));
    }

    public void OnFirstLaunch(InputAction.CallbackContext input)
    {
        if (mFirstLaunch)
        {
            GameManager.instance.State = GameState.PLAYING;
            mCommandProcessor.ExecuteCommand(new ShootCommand(this, Time.timeSinceLevelLoad, GenerateXDirection(), movingSpeed));
            mFirstLaunch = false;
        }
    }

    /* Generates a random float between [-1.5, -0.5] and [0.5, 1.5] */
    private float GenerateXDirection()
    {
        // Randomly decide on the sign
        if (Random.Range(0,3) % 2 == 0)
            return Random.Range(0.5f, 1.5f);
        else
            return -1f * Random.Range(0.5f, 1.5f);
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
