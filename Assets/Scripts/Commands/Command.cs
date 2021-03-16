using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected IEntity mEntity;

    public Command(IEntity entity)
    {
        mEntity = entity;
    }

    public abstract void Execute();

    public abstract void Undo();

}
