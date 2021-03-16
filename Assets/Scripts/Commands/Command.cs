using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected IEntity mEntity;
    protected float mTime;

    public Command(IEntity entity, float time)
    {
        mEntity = entity;
        mTime = time;
    }

    public abstract void Execute();

    public abstract void Undo();

    public float GetTime()
    {
        return mTime;
    }
}
