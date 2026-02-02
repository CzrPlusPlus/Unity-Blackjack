using UnityEngine;

public class Player : Agent
{
    [SerializeField] private GameManager gameManager;
    private float leftCardX = -1f;
    private float leftCardY = -3f;
    private float leftCardZ = 0;
    private float rightCardX = 1f;
    private float rightCardY = -3f;
    private float rightCardZ = 0;
    private float rightMostX = 1f;

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
                Vector3 leftCardPos = new Vector3(leftCardX, leftCardY, leftCardZ);
                currentHand.AddCardToHand(card);
                SpawnCardPrefab(newCard, leftCardPos, transform);  // will need to store these prefab references to delete them safely
                break;
            case 1:
                Vector3 rightCardPos = new Vector3(rightCardX, rightCardY, rightCardZ);
                currentHand.AddCardToHand(card);
                SpawnCardPrefab(newCard, rightCardPos, transform); // will need to store these prefab references to delete them safely
                break;
            default:
                Debug.Log("Getting extra card now");
                Vector3 newCardPos = new Vector3(rightMostX + 2f, rightCardY, rightCardZ);
                currentHand.AddCardToHand(card);
                SpawnCardPrefab(newCard, newCardPos, transform);   // will need to store these prefab references to delete them safely
                transform.position += new Vector3(-1f, 0f, 0f);
                rightMostX += 1f;
                break;
        }
    }

    protected override void Stand()
    {
        Debug.Log("I am the player and I want to stand!");
    }

    private void DoubleDown()
    {
        Debug.Log("I am the player and I want to double down");
    }

    public void RequestHit(Card card)
    {
        Hit(card);
    }

    public void OnHitButton()
    {
        gameManager.RequestDeal();
    }

    public void OnStandButton()
    {
        gameManager.CheckDealerAction();
    }

    public void OnDoubleDownButton()
    {
        DoubleDown();
    }
}
