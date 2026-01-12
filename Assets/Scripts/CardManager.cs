using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cardPrefabs;
    [SerializeField] private GameObject hiddenCard;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform dealerHand;
    private float leftCardX = -1f;
    private float leftCardY = -3f;
    private float leftCardZ = 0;
    private float rightCardX = 1f;
    private float rightCardY = -3f;
    private float rightCardZ = 0;
    private bool firstCardsDealt = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DealInitialCards();
    }

    void DealToDealer()
    {
        if (!firstCardsDealt)
        {
            Vector3 leftCardPos = new Vector3(leftCardX, -leftCardY, leftCardZ);
            Vector3 rightCardPos = new Vector3(rightCardX, -rightCardY, rightCardZ);
            SpawnCardPrefab(leftCardPos, 13, false);    // need to replace with random card index
            SpawnCardPrefab(rightCardPos, -1, false);  // need to replace with random card index
        }
    }

    void DealToPlayer()
    {
        if (!firstCardsDealt)
        {
            Vector3 leftCardPos = new Vector3(leftCardX, leftCardY, leftCardZ);
            Vector3 rightCardPos = new Vector3(rightCardX, rightCardY, rightCardZ);
            SpawnCardPrefab(leftCardPos, 0, true);    // need to replace with random card index
            SpawnCardPrefab(rightCardPos, 12, true);  // need to replace with random card index
            firstCardsDealt = true;
        }
    }

    void DealInitialCards()     // 2 cards to dealer, 2 cards to player. 1 card is face down for the dealer
    {
        DealToDealer();
        DealToPlayer();
    }

    void SpawnCardPrefab(Vector3 spawnPos, int cardIndex, bool playerCards)
    {
        if (playerCards)
        {
            Instantiate(cardPrefabs[cardIndex], spawnPos, Quaternion.identity, playerHand);
        }
        else
        {
            if (cardIndex == -1)
            {
                Instantiate(hiddenCard, spawnPos, Quaternion.identity, dealerHand);
                return;
            }
            Instantiate(cardPrefabs[cardIndex], spawnPos, Quaternion.identity, dealerHand);
        }
    }
}
