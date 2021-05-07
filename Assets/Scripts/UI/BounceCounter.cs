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
        BallController.OnBounce += AddBounce;
   }

   public void AddBounce()
   {
        Debug.Log("Bounce");
   		NumberOfBounces++;
   }



}
  