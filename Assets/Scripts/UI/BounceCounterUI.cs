using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BounceCounterUI : MonoBehaviour
{
    private TextMeshProUGUI bounceText;
    
    private int numBounces;

    private void Awake()
    {
        bounceText = gameObject.GetComponent<TextMeshProUGUI>();
        BallController.OnBounce += AddBounce;
        GameOverScript.OnResetRequest += ResetBounces;
    }

    private void Start()
    {
        numBounces = 0;
        UpdateBounceUI();
    }

    private void UpdateBounceUI()
    {
        bounceText.text = numBounces.ToString();
    }

    public void AddBounce()
    {
        numBounces++;
        UpdateBounceUI();
    }

    private void ResetBounces()
    {
        numBounces = 0;
        UpdateBounceUI();
    }

}
