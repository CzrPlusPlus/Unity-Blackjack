using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Agent : MonoBehaviour
{
    protected List<String> currentHand;
    protected int currentTotal;
    protected float rightCardXPos;
    protected abstract void Hit();
    protected abstract void Stand();
}
