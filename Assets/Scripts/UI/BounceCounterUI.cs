using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BounceCounterUI : MonoBehaviour
{
    private TextMeshProUGUI bounceText;
    private BounceCounter bounceCounter;
    private int lastBounces;

    private void Awake()
    {
        bounceText = FindObjectOfType<TextMeshProUGUI>();
        bounceCounter = FindObjectOfType<BounceCounter>();
    }

    private void Start()
    {
        UpdateBounceUI();
    }

    private void UpdateBounceUI()
    {
        lastBounces = bounceCounter.NumberOfBounces;
        SetText(lastBounces);
    }

    private void Update()
    {
        if (lastBounces != bounceCounter.NumberOfBounces)
        {
            UpdateBounceUI();
        }
    }

    private void SetText(int numBounces)
    {
        bounceText.text = numBounces.ToString();
    }

}
