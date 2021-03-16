using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    // Defines the methods and properties all of our game objects should have
    Transform transform { get; }
    
    public Vector2 GetVelocity();
    public void SetVelocity(Vector2 vel);
}
