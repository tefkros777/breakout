using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchpadController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private Rigidbody2D rb;  
    private Vector2 mInputDirection;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move(mInputDirection);
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        mInputDirection = input.ReadValue<Vector2>();
    }

    public void Move(Vector2 direction)
    {
        var myVelocity = rb.velocity;
        myVelocity.x = direction.x * speed;
        rb.velocity = myVelocity;
    }
}
