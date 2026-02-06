using UnityEngine;

/* EXAMPLE OF INHERITANCE. PLAYER CLASS INHERITS FROM AGENT CLASS. */
public class Player : Agent
{
    [SerializeField] private GameManager gameManager;

    protected override void Hit(Card card)  // POLYMORPHISM
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

    private void DestroyCards()
    {
        DestroyAll();
    }

    /* ABSTRACTION + ENCAPSULATION */
    public void RequestHit(Card card) { Hit(card); }
    public void OnHitButton() { gameManager.RequestDeal(); }
    public void OnStandButton() { gameManager.StartCoroutine(gameManager.CheckDealerAction()); }
    public void OnDoubleDownButton() { gameManager.RequestDeal(true); }
    public void ClearHand() { DestroyCards(); }
}
