using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // Import XR Interaction Toolkit namespace


public class cardGrabTest : MonoBehaviour
{
    [Header("Settings")]
    public portal linkedPortal;
    public portal destinationPortal;
    public XRGrabInteractable grabInteractable; // Reference to the XR Grab Interactable component
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable.onSelectEntered.AddListener(HandleGrab); // Add listener for grab event
    }
    void HandleGrab(XRBaseInteractor interactor)
    {

        traveller playerTraveller = interactor.GetComponentInParent<traveller>();
        if (playerTraveller != null && destinationPortal != null && destinationPortal.linkedPortal != null)
        {
            // Calculate the teleport destination
            Vector3 destinationPosition = destinationPortal.linkedPortal.transform.position;
            Quaternion destinationRotation = destinationPortal.linkedPortal.transform.rotation;

            // Teleport the player
            playerTraveller.teleport(destinationPortal.transform, destinationPortal.linkedPortal.transform, destinationPosition, destinationRotation);
        }
    }
    void Test()
    {
        Debug.Log("SELECTED");
    }
    void OnDestroy()
    {
        grabInteractable.onSelectEntered.RemoveListener(HandleGrab); // Remove listener to prevent memory leaks
    }
    // Update is called once per frame
    void Update()
    {

    }
}

