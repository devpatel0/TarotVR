using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public bool ObjectIsInside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        // UnityEngine.Debug.Log("Object Entered Collider");
        ObjectIsInside = true;
    }

    void OnTriggerExit(Collider other) {
        // UnityEngine.Debug.Log("Object Exited Collider");
        ObjectIsInside = false;
    }
}
