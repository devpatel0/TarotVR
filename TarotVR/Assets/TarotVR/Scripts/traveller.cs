using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traveller : MonoBehaviour
{
    public Vector3 previousOffsetFromPortal {get;set;}

    public virtual void teleport(Transform fromPortal, Transform toPortal, Vector3 position, Quaternion rotation) {
        transform.position = position;
        transform.rotation = rotation;
        Debug.Log("Teleported from: " + fromPortal.position);
        Debug.Log("Teleported to: " + toPortal.position);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
