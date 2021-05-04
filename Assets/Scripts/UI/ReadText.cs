using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadText : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<TMP_InputField>().onEndEdit.AddListener(handleTextInput);
    }

    private void handleTextInput(string txt)
    {
        Debug.Log(txt);
    }
}
