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
    private GameObject newCard; // Reference to the selected new card
    public GameObject cardPrefab; // Prefab to instantiate for the newCard
    public float shuffleDuration = 3f; // Duration of the shuffle before selecting a card
    private bool isShuffling = false; // Is a shuffle currently happening?

    void Start()
    {
        Shuffle();
    }

    void Shuffle()
    {
        if (isShuffling) return; // Prevent re-entry if shuffle is already happening

        isShuffling = true;
        StartCoroutine(ShuffleRoutine());
    }

    IEnumerator ShuffleRoutine()
    {
        // Cards shuffle for a few seconds
        float startTime = Time.time;

        while (Time.time - startTime < shuffleDuration)
        {
            // Keep moving cards until shuffle duration is met
            moveCards();
            yield return null;
        }

        // Select a random card (for simplicity, this example re-instantiates it at the endPosition)
        newCard = Instantiate(cardPrefab, endPosition, Quaternion.identity);

        // Sparkles or any other visual effect

        // Delete all child cards
        foreach (Transform child in transform)
        {
            if (child.gameObject != newCard) // Preserve the new card if it's a child; adjust logic as needed
                Destroy(child.gameObject);
        }

        isShuffling = false;
    }

    void moveCards()
    {
        // Iterate through all children and interpolate their position to the global endPosition
        foreach (Transform child in transform)
        {
            child.transform.position = Vector3.Lerp(child.transform.position, endPosition, cardMoveSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        // If you want to continuously test the moveCards method, you can call Shuffle here
        // But it's better to trigger Shuffle from a specific event (e.g., player action)
    }
}
