using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCounter : MonoBehaviour
{
   // All this does is keep track of how many bounces happen

   public int NumberOfBounces { get; private set; }

   private void Awake()
   {
   		NumberOfBounces = 0;
        BounceCommand.OnBounce += AddBounce;
   }

   public void AddBounce()
   {
   		NumberOfBounces++;
        Debug.Log("Bounce event");
   }

}
  