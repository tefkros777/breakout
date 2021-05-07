using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : Command
{
    // All data that defines this command
    private float mDirectionX;
    private float mDirectionY;

    public ShootCommand(IEntity entity, float time, float x, float y) : base(entity, time)
    {
        mDirectionX = x;
        mDirectionY = y;
    }

    public override void Execute()
    {
        mEntity.SetVelocity(new Vector2(mDirectionX, -mDirectionY));
        Debug.Log($"SHOOTING AT {mDirectionX}, {-mDirectionY}");
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }

}
