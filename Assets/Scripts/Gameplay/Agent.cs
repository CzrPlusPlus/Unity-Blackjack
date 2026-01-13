using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Agent : MonoBehaviour
{
    protected Hand currentHand;
    protected abstract void Hit();
    protected abstract void Stand();
}
