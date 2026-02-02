using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Agent : MonoBehaviour
{
    public Hand currentHand { get; private set; }
    protected List<GameObject> cardPrefabs;

    protected virtual void Awake()
    {
        currentHand = new Hand();
    }

    protected virtual GameObject SpawnCardPrefab(GameObject card, Vector3 spawnPos, Transform parent)
    {
        return Instantiate(card, spawnPos, Quaternion.identity, parent);
    }

    protected abstract void Hit(Card card);
    protected abstract void Stand();   
}
