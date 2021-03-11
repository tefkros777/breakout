using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody2D rigidbody;
    private Collider2D ballCollider;
    private Collider2D dockCollider;

    private bool isDocked = false;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        ballCollider = gameObject.GetComponent<CircleCollider2D>();
        dockCollider = GameObject.FindGameObjectWithTag("Dock").GetComponent<CapsuleCollider2D>();
        isDocked = false;
    }

    void Update()
    {
        dockCheck();
    }

    private void dockCheck()
    {
        if (ballCollider.IsTouching(dockCollider)){
            isDocked = true;
        }
        else
        {
            isDocked = false;
        }
    }
}
