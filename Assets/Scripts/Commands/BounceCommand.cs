using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BounceCommand : Command
{
    // All data that defines this command
    Vector2 mIncomingVelocity;
    ContactPoint2D mCollisionPoint;
    private float mSpeed;

    public static event Action OnBounce;

    // For optimization
    private Vector2 newDirection;

    public BounceCommand(IEntity entity, float time, Vector2 incomingVelocity, ContactPoint2D collisionPoint, float speed) : base (entity, time)
    {
        mIncomingVelocity = incomingVelocity;
        mCollisionPoint = collisionPoint;
        mSpeed = speed;
    }

    public override void Execute()
    {
        OnBounce?.Invoke();
        newDirection = Vector2.Reflect(mIncomingVelocity.normalized, mCollisionPoint.normal);
        mEntity.SetVelocity(newDirection * mSpeed);
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}
