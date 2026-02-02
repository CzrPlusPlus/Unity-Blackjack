using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject hiddenCard;
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

    void DealInitialCards()
    {
        player.OnHitButton(shoe.DealCard());
        dealer.RequestHit(shoe.DealCard());
        player.OnHitButton(shoe.DealCard());
        dealer.RequestHit(shoe.DealCard());
    }
}
