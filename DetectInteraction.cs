using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Detects interactive elements the player is looking at.
/// </summary>
public class DetectInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializedFeild]
    public Transform raycastOrigin;

  
    [Tooltip("How far from the raycastorigin we will search for interactive elements.")]
    [SerializedFeild]
    public float maxRange = 5.0f;

    public IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        IInteractive interactive = null;

        if (objectWasDetected)
        {
            //Debug.Log ("Player is looking at: " + hitInfo.collider.gameObject.name);
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        if (interactive != null)
            lookedAtInteractive = interactive;
                

    }
}