using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking at IInteractive,
/// and then calls that IInteractive's interact button.
/// </summary>
public class Interactwithlookedat : MonoBehaviour
{
    [SerializedFeild]
    private DetectInteraction detectInteractive;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
             Debug.Log("Player pressed the interact button.");
        }
    }
}
