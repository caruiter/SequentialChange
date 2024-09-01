//Callandra Ruiter GDD410
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//this script activates the event Change
//this script doesn't need to be placed in a specific point but the resulting actions need to be assigned to Change in the inspector

public class ControllerScript : MonoBehaviour
{
    public UnityEvent Change;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Change.Invoke();
        }
    }
}
