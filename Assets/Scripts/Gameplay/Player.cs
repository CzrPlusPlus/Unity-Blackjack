using UnityEngine;

public class Player : Agent
{
    private float leftCardX = -1f;
    private float leftCardY = -3f;
    private float leftCardZ = 0;
    private float rightCardX = 1f;
    private float rightCardY = -3f;
    private float rightCardZ = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hit();
        // Stand();
    }

    protected override void Hit()
    {
        //Debug.Log("I am the player and I want to hit!");
        Debug.Log("I am the player and this is how many cards I have currently: " + currentHand.CardCount);
    }

    protected override void Stand()
    {
        Debug.Log("I am the player and I want to stand!");
    }

    private void DoubleDown()
    {
        Debug.Log("I am the player and I want to double down");
    }

    public void OnHitButton()
    {
        Hit();
    }

    public void OnStandButton()
    {
        Stand();
    }

    public void OnDoubleDownButton()
    {
        DoubleDown();
    }
}
