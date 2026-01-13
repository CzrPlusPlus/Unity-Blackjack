using UnityEngine;

/* THIS SCRIPT IS NO LONGER NEEDED. USE IT AS A REFERENCE TO MAKE THE ACTUAL SCRIPT GameManger.cs  */
public class CardManager : MonoBehaviour
{
    // [SerializeField] private GameObject hiddenCard;
    // [SerializeField] private Transform playerHand;
    // [SerializeField] private Transform dealerHand;
    // private float leftCardX = -1f;
    // private float leftCardY = -3f;
    // private float leftCardZ = 0;
    // private float rightCardX = 1f;
    // private float rightCardY = -3f;
    // private float rightCardZ = 0;
    // private bool firstCardsDealt = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // DealInitialCards();
    }

    // void DealToDealer()
    // {
    //     if (!firstCardsDealt)
    //     {
    //         Vector3 leftCardPos = new Vector3(leftCardX, -leftCardY, leftCardZ);
    //         Vector3 rightCardPos = new Vector3(rightCardX, -rightCardY, rightCardZ);
    //         SpawnCardPrefab(leftCardPos, 13, false);    // need to replace with random card index
    //         SpawnCardPrefab(rightCardPos, -1, false);  // need to replace with random card index
    //         return;
    //     }
    // }

    // public void DealToPlayer()
    // {
    //     if (!firstCardsDealt)
    //     {
    //         Vector3 leftCardPos = new Vector3(leftCardX, leftCardY, leftCardZ);
    //         Vector3 rightCardPos = new Vector3(rightCardX, rightCardY, rightCardZ);
    //         SpawnCardPrefab(leftCardPos, 0, true);    // need to replace with random card index
    //         SpawnCardPrefab(rightCardPos, 12, true);  // need to replace with random card index
    //         firstCardsDealt = true;
    //         return;
    //     }
    //     Vector3 newCardPos = new Vector3(rightCardX + 2f, rightCardY, rightCardZ);  // NEED TO REDO THIS LINE OF CODE SO IT WORKS WELL FOR MORE THAN JUST THE FIRST EXTRA CARD
    //     SpawnCardPrefab(newCardPos, 33, true);    // need to replace with random card index
    //     ShiftCardsOver(true);
    // }

    // void DealInitialCards()     // 2 cards to dealer, 2 cards to player. 1 card is face down for the dealer
    // {
    //     DealToDealer();
    //     DealToPlayer();
    // }

    // void SpawnCardPrefab(Vector3 spawnPos, int cardIndex, bool playerCards)
    // {
    //     if (playerCards)    // instantiate prefabs as a child of the playerHand gameObject
    //     {
    //         Instantiate(cardPrefabs[cardIndex], spawnPos, Quaternion.identity, playerHand); 
    //     }
    //     else                // instantiate prefabs as a child of the dealerHand gameObject
    //     {
    //         if (cardIndex == -1)
    //         {
    //             Instantiate(hiddenCard, spawnPos, Quaternion.identity, dealerHand);
    //             return;
    //         }
    //         Instantiate(cardPrefabs[cardIndex], spawnPos, Quaternion.identity, dealerHand);
    //     }
    // }

    // void ShiftCardsOver(bool playerCards)
    // {
    //     if (playerCards)
    //     {
    //         playerHand.position += new Vector3(-1f, 0f, 0f);
    //         return;
    //     }
    //     dealerHand.position += new Vector3(-1f, 0f, 0f);
    // }
}
