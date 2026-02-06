using UnityEngine;
using System.Collections.Generic;
using System;

/* THIS CLASS IS MADE AS A PARENT CLASS FROM WHICH TWO OTHER CLASSES WILL INHERIT */
public abstract class Agent : MonoBehaviour
{
    public Hand currentHand { get; private set; }   // Holds a list of Card objects with a few methods
    protected List<GameObject> cardPrefabs;         // Holds references to the gameobjects that are dynamically instantiated
    
    // World Coords for Card GameObject Instantiating
    protected float leftCardX = -1f;
    protected float leftCardY = -3f;  // needs to be +3f for dealer
    protected float leftCardZ = 0;
    protected float rightCardX = 1f;
    protected float rightCardY = -3f; // needs to be +3f for dealer
    protected float rightCardZ = 0;
    protected float rightMostX = 1f;

    protected virtual void Awake()
    {
        currentHand = new Hand();
        cardPrefabs = new List<GameObject>();
    }

    protected virtual GameObject SpawnCardPrefab(GameObject card, Vector3 spawnPos, Transform parent)
    {
        return Instantiate(card, spawnPos, Quaternion.identity, parent);
    }

    protected virtual void DestroyAll()
    {
        if (cardPrefabs.Count > 0)
        {
            foreach (var card in cardPrefabs)
            {
                Destroy(card);
            }
            cardPrefabs.Clear();
            currentHand.Cards.Clear();
            rightMostX = 1f;
        }
    }

    protected abstract void Hit(Card card); 
}
