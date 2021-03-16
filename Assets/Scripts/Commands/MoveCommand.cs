using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    // All data that defines this command
    private Vector2 mDirection;
    private float mSpeed;

    // For optimization
    private Vector2 myVelocity;

    public MoveCommand(IEntity entity, float time, Vector2 direction, float speed) : base(entity, time)
    {
        // Entity is processed by tha base class
        mDirection = direction;
        mSpeed = speed;
    }
    

    public override void Execute()
    {
        myVelocity = mEntity.GetVelocity();
        myVelocity.x = mDirection.x * mSpeed; //  maybe speed
        mEntity.SetVelocity(myVelocity);
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}
