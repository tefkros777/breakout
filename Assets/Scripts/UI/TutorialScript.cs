using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject TutorialUI;

    public void HideTutorial()
    {
        Debug.Log("Hiding Tutorial");

        TutorialUI.SetActive(false);
    }

}
