using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PillarManager : MonoBehaviour
{
    public Pillar pillarOne;
    public Pillar pillarTwo;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pillarOne.ObjectIsInside && pillarTwo.ObjectIsInside) {
            Animator doorOpen = GameObject.Find("door").GetComponent<Animator>();
            // Debug.Log("Both Pedestals are Filled!");
            // Do door animation
            doorOpen.SetBool("openDoor", true);
            // Set to false
            pillarOne.ObjectIsInside = false;
            pillarTwo.ObjectIsInside = false;
        }   
    }
}
