using UnityEngine;

public class Player : Agent
{
    [SerializeField] private GameManager gameManager;

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
                cardPrefabs.Add(SpawnCardPrefab(newCard, leftCardPos, transform));  
                break;
            case 1:
                Vector3 rightCardPos = new Vector3(rightCardX, rightCardY, rightCardZ);
                currentHand.AddCardToHand(card);
                cardPrefabs.Add(SpawnCardPrefab(newCard, rightCardPos, transform)); 
                break;
            default:
                Vector3 newCardPos = new Vector3(rightMostX + 2f, rightCardY, rightCardZ);
                currentHand.AddCardToHand(card);
                cardPrefabs.Add(SpawnCardPrefab(newCard, newCardPos, transform));   
                transform.position += new Vector3(-1f, 0f, 0f);
                rightMostX += 1f;
                break;
        }
    }

    [ContextMenu("Destroy All Card Objects")]
    private void DestroyCards()
    {
        DestroyAll();
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
        gameManager.StartCoroutine(gameManager.CheckDealerAction());
    }

    public void OnDoubleDownButton()
    {
        DoubleDown();
    }

    public void ClearHand() { DestroyCards(); }
}
