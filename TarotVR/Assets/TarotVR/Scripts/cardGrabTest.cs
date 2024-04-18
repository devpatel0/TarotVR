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
    public GameObject portalModel;
    public portal removeTraveller;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable.onSelectEntered.AddListener(HandleGrab); // Add listener for grab event
        grabInteractable.onSelectExited.AddListener(HandleRelease); // Add listener for release event
        linkedPortal.gameObject.SetActive(false);
        portalModel.gameObject.SetActive(false);

    }
    void HandleGrab(XRBaseInteractor interactor)
    {
        // Show the portal when the card is grabbed
        if(linkedPortal != null)
        {
            linkedPortal.gameObject.SetActive(true);
        }
        if (portalModel) {
            portalModel.gameObject.SetActive(true);
        }
    }
    void HandleRelease(XRBaseInteractor interactor)
    {
        // Hide the portal when the card is released
        if(linkedPortal != null)
        {
            linkedPortal.gameObject.SetActive(false);
        }
        if(portalModel) {
            portalModel.gameObject.SetActive(false);
        }
    }

    public void DeactivatePortal() {
        // Hide the portal
        if(linkedPortal != null)
        {
            linkedPortal.gameObject.SetActive(false);
        }
        if(portalModel) {
            portalModel.gameObject.SetActive(false);
        }
    }
    
    void Test()
    {
        Debug.Log("SELECTED");
    }
    void OnDestroy()
    {
        grabInteractable.onSelectEntered.RemoveListener(HandleGrab); // Remove listener to prevent memory leaks
        grabInteractable.onSelectExited.RemoveListener(HandleRelease); // Remove listener to prevent memory leaks
    }
    // Update is called once per frame
    void Update()
    {

    }
}

