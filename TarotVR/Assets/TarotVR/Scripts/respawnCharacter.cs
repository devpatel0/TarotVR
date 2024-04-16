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
    // When player enters respawn collider
    void OnTriggerEnter(Collider other) {
        // Teleport player to desired location
        other.transform.position = spawnPoint;
        other.transform.rotation = spawnRotation;
        // Find card shuffle component
        CardShuffle cardShuffle = GameObject.Find("Cards").GetComponent<CardShuffle>();
        // Reset card shuffle
        cardShuffle.Reset();
    }
}
