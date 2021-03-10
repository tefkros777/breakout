using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchpadBehaviour : MonoBehaviour
{
    private void Awake()
    {
        // Cache components
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        Debug.Log(input);
    }
}
