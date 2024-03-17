using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class portal : MonoBehaviour
{
    [Header ("Settings")]
    public portal linkedPortal;

    private Camera xrCamera;
    private List<traveller> trackedTravellers; 

    // Start is called before the first frame update
    void Start()
    {
        xrCamera = Camera.main;
        trackedTravellers = new List<traveller> ();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        HandleTravellers();
    }

    void HandleTravellers() {
        for (int i = 0; i < trackedTravellers.Count; i++ ) {
            traveller portalTraveller = trackedTravellers[i];
            Transform travellerTansform = portalTraveller.transform;
            var m = linkedPortal.transform.localToWorldMatrix * transform.worldToLocalMatrix * travellerTansform.transform.localToWorldMatrix;

            Vector3 portalOffset = travellerTansform.position - transform.position;
            int isOnPortalSide = System.Math.Sign(Vector3.Dot(portalOffset, transform.forward));
            int oldPortalSide = System.Math.Sign(Vector3.Dot(portalTraveller.previousOffsetFromPortal, transform.forward));

            if (isOnPortalSide != oldPortalSide) {
                var oldPosition = travellerTansform.position;
                var oldRotation = travellerTansform.rotation;
                portalTraveller.teleport(transform, linkedPortal.transform, m.GetColumn(3), m.rotation);
                // graphics clone?
                linkedPortal.onTravellerEnterPortal(portalTraveller);
                trackedTravellers.RemoveAt(i);
                i--;
            } else {
                portalTraveller.previousOffsetFromPortal = portalOffset;
            }
        }
    }

    void onTravellerEnterPortal(traveller portalTraveller) {
        if (!trackedTravellers.Contains(portalTraveller)) {
            portalTraveller.previousOffsetFromPortal = portalTraveller.transform.position - transform.position;
            trackedTravellers.Add(portalTraveller);
        }
    }

    void OnTriggerEnter(Collider other) {
        var portalTraveller = other.GetComponent<traveller> ();
        if (portalTraveller) {
            onTravellerEnterPortal(portalTraveller);
        }
        Debug.Log("Player Enter");
    }

    void OnTriggerExit(Collider other) {
        var portalTraveller = other.GetComponent<traveller> ();
        if (portalTraveller && trackedTravellers.Contains(portalTraveller)) {
            trackedTravellers.Remove(portalTraveller);
        }
        Debug.Log("Player Exit");
    }
}
