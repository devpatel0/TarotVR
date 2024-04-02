using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Animations;
using Unity.Mathematics;
using System;
public class CardShuffle : MonoBehaviour
{
    public Vector3 endPosition; // Point where cards will end up after "shuffle"
    public float cardMoveSpeed = 50f; // Speed of card movement
    // private Card newCard;

    void Start()
    {
        Shuffle();
    }

    // Update is called once per frame
    void Shuffle()
    {
        // Pick random card
        // newCard = randomCard();

        // Cards shuffle for a few seconds
        // Cards merge to one position
        // Other cards are deleted
            // moveCards();

        // Random card is instantiated
        // instantiate newCard at pos...

        // Sparkles
    }

    // Card randomCard(){
        // newCard.randomize();
    // }
    void moveCards(){
        // Iterate through all children
        foreach(Transform child in transform) {
            // Interpolate it's position to a global position
            child.transform.position = new Vector3(
                Mathf.Lerp(child.transform.position.x, endPosition.x, cardMoveSpeed * Time.deltaTime), 
                Mathf.Lerp(child.transform.position.y, endPosition.y, cardMoveSpeed * Time.deltaTime), 
                Mathf.Lerp(child.transform.position.z, endPosition.z, cardMoveSpeed * Time.deltaTime)
            );
        }

        // Delete all child cards after a few seconds

    }

    // void onPlayerEnterSpawnRoom(){
        // Shuffle();
    // }

    void Update() {
        // test for moveCards
        moveCards();
    }
}