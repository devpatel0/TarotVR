using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // Import XR Interaction Toolkit namespace


public class cardGrabTest : MonoBehaviour
{
    [Header("Settings")]
    public portal linkedPortal;
    public Animator portalEffect;
    public XRGrabInteractable grabInteractable; // Reference to the XR Grab Interactable component
    public GameObject portalModel;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable.onSelectEntered.AddListener(HandleGrab); // Add listener for grab event
        grabInteractable.onSelectExited.AddListener(HandleRelease); // Add listener for release event
        linkedPortal.gameObject.SetActive(false);
        portalModel.gameObject.SetActive(false);
        portalEffect.gameObject.SetActive(false);

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
        if (portalEffect) {
            portalEffect.gameObject.SetActive(true);
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
        if (portalEffect) {
            portalEffect.gameObject.SetActive(false);
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
        if (portalEffect) {
            portalEffect.gameObject.SetActive(false);
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

