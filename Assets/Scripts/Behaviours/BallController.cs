using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CommandProcessor))]
[RequireComponent(typeof(SpriteRenderer))]
public class BallController : MonoBehaviour, IEntity
{

    [SerializeField] private float movingSpeed;
    [SerializeField] private Sprite[] sprites;

    private Vector2 lastVelocity;
    private bool mFirstLaunch = true;

    private Rigidbody2D rb;
    private CommandProcessor mCommandProcessor;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mCommandProcessor = gameObject.GetComponent<CommandProcessor>();
    }

    private void Start()
    {
        // Set random sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
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

    public void OnFirstLaunch(InputAction.CallbackContext input)
    {
        if (mFirstLaunch)
        {
            mCommandProcessor.ExecuteCommand(new ShootCommand(this, Time.timeSinceLevelLoad, GenerateXDirection(), movingSpeed));
            mFirstLaunch = false;
        }
    }

    // Generates a random float between [-1.5, -0.5] and [0.5, 1.5]
    private float GenerateXDirection()
    {
        float num = Random.Range(-1.5f, 1.5f);
        // Discard value between -0.5 and 0.5 as they are too small to reflect on X axis
        while (num > -0.5 && num < 0.5)
            num = Random.Range(-1.5f, 1.5f);
        return num;
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
