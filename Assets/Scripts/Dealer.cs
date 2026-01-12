using UnityEngine;

public class Dealer : Agent
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // to do
    }

    protected override void Hit()
    {
        Debug.Log("I am the dealer and I want to hit!");
    }

    protected override void Stand()
    {
        Debug.Log("I am the dealer and I want to stand!");
    }

    public void OnHitButton()
    {
        Hit();
    }

    public void OnStandButton()
    {
        Stand();
    }
}
