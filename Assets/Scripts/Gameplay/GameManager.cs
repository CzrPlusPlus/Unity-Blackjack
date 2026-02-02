using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Dealer dealer;
    private Shoe shoe;
    //private bool firstCardsDealt = false;

    /* What are the chronological steps that happen in a blackjack game? 
    1. Shoe must be made and shuffled
    2. Deal cards to player and dealer with one card hidden for the dealer
    3. Check game state as the game may be over already
    4. If game not over, check player action
    5. If player doesn't bust, check dealer action
    6. If dealer stands, check who wins
    7. If dealer hits, check conditions again until step 6 is done or dealer busts
    */

    void Awake()
    {
        shoe = new Shoe();
    }

    void Start()
    {
        shoe.Initialize();  // this accomplishes step 1
        DealInitialCards();
    }

    void CheckGameState()
    {
        /* 4 Possible Game States:
        1. No one has blackjack (Await player action)
        2. Only dealer has blackjack (dealer wins)
        3. Only player has blackjack (player wins)
        4. Both dealer & player have blackjack (tie) 
        */
        Debug.Log("Checking Game State...");
        if (!dealer.currentHand.isBlackjack && !player.currentHand.isBlackjack)
        {
            Debug.Log("Game can continue.");
        }
        else if (dealer.currentHand.isBlackjack && !player.currentHand.isBlackjack)
        {
            Debug.Log("Dealer wins. Reveal hidden card.");
            // reveal hidden card
        }
        else if (!dealer.currentHand.isBlackjack && player.currentHand.isBlackjack)
        {
            Debug.Log("Player wins. Reveal hidden card.");
            // reveal hidden card
        }
        else
        {
            Debug.Log("It's a tie. Reveal hidden card.");
            // reveal hidden card
        }
    }

    void DealInitialCards()
    {
        player.RequestHit(shoe.DealCard());
        dealer.RequestHit(shoe.DealCard());
        player.RequestHit(shoe.DealCard());
        dealer.RequestHit(shoe.DealCard());
        CheckGameState();
    }

    public void RequestDeal()
    {
        player.RequestHit(shoe.DealCard());
    }

    public void CheckDealerAction()
    {
        if (dealer.ShouldHit)
        {
            dealer.RequestHit(shoe.DealCard());
        }
    }
}
