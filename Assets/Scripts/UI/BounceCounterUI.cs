using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BounceCounterUI : MonoBehaviour
{
    private TextMeshProUGUI bounceText;
    
    private int numBounces;

    private void Awake()
    {
        bounceText = FindObjectOfType<TextMeshProUGUI>();
        BounceCommand.OnBounce += AddBounce;
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

}
