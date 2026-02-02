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

    protected override void Hit(Card card)
    {
        GameObject newCard = CardPrefabDatabase.Instance.GetPrefab(card);

        switch (currentHand.CardCount)
        {
            case 0: 
                Debug.Log("Getting first card now");
                Vector3 leftCardPos = new Vector3(leftCardX, leftCardY, leftCardZ);
                currentHand.AddCardToHand(card);
                SpawnCardPrefab(newCard, leftCardPos);
                break;
            case 1:
                Debug.Log("Getting second card now");
                Vector3 rightCardPos = new Vector3(rightCardX, rightCardY, rightCardZ);
                currentHand.AddCardToHand(card);
                SpawnCardPrefab(newCard, rightCardPos);
                break;
            default:
                Debug.Log("Getting extra card now");
                currentHand.AddCardToHand(card);
                break;
        }
    
        //Debug.Log("I am the player and I want to hit!");
        // if (currentHand.CardCount == 0) // left card
        // {
        //     Vector3 leftCardPos = new Vector3(leftCardX, leftCardY, leftCardZ);
        //     GameObject newCard = CardPrefabDatabase.Instance.GetPrefab(card);

        //     currentHand.AddCardToHand(card);
        //     SpawnCardPrefab(newCard, leftCardPos);
            
        // }
        // Debug.Log("I am the player and this is how many cards I have currently: " + currentHand.CardCount);
    }

    protected override void Stand()
    {
        Debug.Log("I am the player and I want to stand!");
    }

    private void DoubleDown()
    {
        Debug.Log("I am the player and I want to double down");
    }

    public void OnHitButton(Card card)
    {
        Hit(card);
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
