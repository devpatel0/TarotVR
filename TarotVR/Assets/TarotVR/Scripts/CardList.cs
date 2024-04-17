using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public GameObject theFool;
    public GameObject theMagician;
    static public List<GameObject> cards;
    static public Vector3 instancePos = new Vector3(0, -5, 0);

    public void Start() {
        cards = new List<GameObject>() {theFool, theMagician};
    }

    public GameObject Randomize() {
        // Random index
        int index = Random.Range(0, cards.Count);
        Debug.Log("Random Card Index: " + index);
        // Select card
        GameObject randCard = cards.ElementAt(index);
        return randCard;
    }
}
