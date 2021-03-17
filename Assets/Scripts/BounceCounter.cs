using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCounter : MonoBehaviour
{
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
  