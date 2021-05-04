using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCounter : MonoBehaviour
{
   // All this does is keep track of how many bounces happen

   public int NumberOfBounces { get; private set; }

    public static int Highscore
    {
        get { return PlayerPrefs.GetInt("Highscore", 0); }
        private set { PlayerPrefs.SetInt("Highscore", value); }
    }

   private void Awake()
   {
   		NumberOfBounces = 0;
        BounceCommand.OnBounce += AddBounce;
   }

   public void AddBounce()
   {
        Debug.Log("Bounce event");
   		NumberOfBounces++;

        if (NumberOfBounces >= Highscore)
        {
            Debug.Log("NEW HIGHSCORE" + NumberOfBounces);
            Highscore = NumberOfBounces;
        }
   }

}
  