using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class respawnCharacter : MonoBehaviour
{
    public Vector3 spawnPoint;
    public quaternion spawnRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        other.transform.position = spawnPoint;
        other.transform.rotation = spawnRotation;
    }
}
