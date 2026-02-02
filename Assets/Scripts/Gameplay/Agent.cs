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

    protected abstract void Hit();
    protected abstract void Stand();
}
