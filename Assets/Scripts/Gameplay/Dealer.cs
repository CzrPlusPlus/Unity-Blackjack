using UnityEngine;

/* EXAMPLE OF INHERITANCE. DEALER CLASS INHERITS FROM AGENT CLASS. */
public class Dealer : Agent
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject hiddenCard;
    private GameObject hiddenPrefab;

    protected override void Hit(Card card)  // POLYMORPHISM
    {
        GameObject newCard = CardPrefabDatabase.Instance.GetPrefab(card);

        switch (currentHand.CardCount)
        {
            case 0: 
                currentHand.AddCardToHand(card);
                Vector3 leftCardPos = new Vector3(leftCardX, leftCardY * -1, leftCardZ);
                hiddenPrefab = SpawnCardPrefab(hiddenCard, leftCardPos, transform);
                cardPrefabs.Add(SpawnCardPrefab(newCard, leftCardPos, transform));
                break;
            case 1:
                currentHand.AddCardToHand(card);
                Vector3 rightCardPos = new Vector3(rightCardX, rightCardY * -1, rightCardZ);
                cardPrefabs.Add(SpawnCardPrefab(newCard, rightCardPos, transform));
                break;
            default:
                Vector3 newCardPos = new Vector3(rightMostX + 2f, rightCardY * -1, rightCardZ);
                currentHand.AddCardToHand(card);
                cardPrefabs.Add(SpawnCardPrefab(newCard, newCardPos, transform)); 
                transform.position += new Vector3(-1f, 0f, 0f);
                rightMostX += 1f;
                gameManager.CheckDealerAction();
                break;
        }
    }

    private void DestroyHidden()
    {
        if (hiddenPrefab != null)
        {
            Destroy(hiddenPrefab);
            hiddenPrefab = null; // Clear reference
        }
    }

    private void DestroyCards()
    {
        DestroyAll();
    }

    /* ABSTRACTION + ENCAPSULATION */
    public bool ShouldHit => currentHand.Total < 17;
    public void RevealHidden() { DestroyHidden(); }
    public void ClearHand() { DestroyCards(); }
    public void RequestHit(Card card) { Hit(card); }
}
