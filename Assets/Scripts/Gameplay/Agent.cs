using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Agent : MonoBehaviour
{
    public Hand currentHand { get; private set; }

    protected virtual void Awake()
    {
        currentHand = new Hand();
    }

    protected virtual void SpawnCardPrefab(GameObject card, Vector3 spawnPos)
    {
        Instantiate(card, spawnPos, Quaternion.identity);
    }

    protected abstract void Hit(Card card);
    protected abstract void Stand();   
}
