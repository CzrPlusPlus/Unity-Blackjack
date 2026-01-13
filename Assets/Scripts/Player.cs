using UnityEngine;

public class Player : Agent
{
    // [SerializeField] private CardManager cardManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hit();
        // Stand();
    }

    protected override void Hit()
    {
        Debug.Log("I am the player and I want to hit!");
        // cardManager.DealToPlayer();
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
