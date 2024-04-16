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
    // private GameObject newCard; // Reference to the selected new card
    // public GameObject cardPrefab; // Prefab to instantiate for the newCard
    public float shuffleDuration = 3f; // Duration of the shuffle before selecting a card
    private bool isShuffling = false; // Is a shuffle currently happening?
    public static CardList cardList; // List of unique cards in scene (located on empty gameobject cardlist in scene)
    public static GameObject newCard; // New card returned from random shuffle
    public GameObject baseCard; // Base card used to reset 10 beginning empty cards
    public static float spacer = 2.0f; // Spacer to help position base cards
    public Vector3 baseCardPosition = new Vector3(3.25f,0.5f,14.0f); // Position for start of base cards
    public static cardGrabTest deactivatePortal; // Used to deactivate portal on newcard when shuffle is reset

    public void Start()
    {
        // Find list of unique cards in scene
        cardList = GameObject.Find("CardList").GetComponent<CardList>();
        Shuffle();
    }

    void Shuffle()
    {
        if (isShuffling) return; // Prevent re-entry if shuffle is already happening

        isShuffling = true;
        StartCoroutine(ShuffleRoutine());
    }

    public void Reset() {
        // Helper for adjusting rotation of instantiated cards
        float yRot = 90f;
        // Deactivate previous card's linked portal
        deactivatePortal = GameObject.Find(newCard.name).GetComponent<cardGrabTest>();
        deactivatePortal.DeactivatePortal();
        // Destroy previous card
        Destroy(newCard);
        // Instance 10 new base cards in a row
        for (int i = 1; i < 11; i++) {
            Vector3 offset = new Vector3(0, 0, spacer * i);
            Instantiate(baseCard, baseCardPosition - offset, Quaternion.Euler(0,yRot,0), this.transform);
        }
        // Call start
        Start();
    }

    IEnumerator ShuffleRoutine()
    {
        // Helper for adjusting rotation of instanced card
        float yRot = -90f;
        // Cards shuffle for a few seconds
        float startTime = Time.time;

        while (Time.time - startTime < shuffleDuration)
        {
            // Keep moving cards until shuffle duration is met
            moveCards();
            yield return null;
        }

        // Delete all child cards
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Select a random card (for simplicity, this example re-instantiates it at the endPosition)
        newCard = cardList.Randomize();
        newCard = Instantiate(newCard, endPosition, Quaternion.Euler(0,yRot,0));

        // Sparkles or any other visual effect

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
