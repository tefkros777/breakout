using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CommandProcessor))]
public class LaunchpadController : MonoBehaviour, IEntity
{
    [SerializeField] private float standardSpeed;
    [SerializeField] private float fastSpeed;
    [SerializeField] private float mSpeed = 5.0f;

    private Rigidbody2D rb;  
    private CommandProcessor mCommandProcessor;
    
    // Player input
    private Vector2 mPlayerInput;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mCommandProcessor = gameObject.GetComponent<CommandProcessor>();
        
        standardSpeed = mSpeed;
        fastSpeed= mSpeed * 2f;
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            Debug.Log("MOVE STARTED");
            mPlayerInput = input.ReadValue<Vector2>();
            mCommandProcessor.ExecuteCommand(new MoveCommand(this, Time.timeSinceLevelLoad, mPlayerInput, mSpeed));
        }
        if (input.canceled)
        {
            Debug.Log("MOVE ENDED");
            mPlayerInput = Vector2.zero; // Cancel any movement
            mCommandProcessor.ExecuteCommand(new MoveCommand(this, Time.timeSinceLevelLoad, mPlayerInput, mSpeed ));
        }
    }

    public void OnAccelerate(InputAction.CallbackContext input)
    {
        if (input.started)
        {
            Debug.Log("FAST SPEED");
            mSpeed = fastSpeed;
        }
        if (input.canceled)
        {
            Debug.Log("NORMAL SPEED");
            mSpeed = standardSpeed;
        }
    }

    // IEntity
    public Vector2 GetVelocity()
    {
        return rb.velocity;
    }

    public void SetVelocity(Vector2 vel)
    {
        rb.velocity = vel;
    }
}
