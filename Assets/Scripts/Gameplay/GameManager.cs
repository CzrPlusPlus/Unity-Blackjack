using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Dealer dealer;
    [SerializeField] private GameObject modalWin;
    [SerializeField] private GameObject modalLoss;
    [SerializeField] private GameObject modalTie;
    [SerializeField] private Button hitButton;  
    [SerializeField] private Button standButton;  
    [SerializeField] private Button doubleDownButton;  
    private Shoe shoe;
    private bool doubleDown = false;
    private bool isGameOver = false;

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

    void Update()
    {
        // while (isGameOver)
        // {
        //     if (Keyboard.current.enterKey.wasPressedThisFrame)
        //     {
        //         NewGame();
        //     }
        // }
    }

    void PlayerWin()
    {
        Debug.Log("Player wins. Reveal hidden card.");
        dealer.RevealHidden();
        isGameOver = true;
        modalWin.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        doubleDownButton.gameObject.SetActive(false);
        //NewGame();
    }

    void DealerWin()
    {
        Debug.Log("Dealer wins. Reveal hidden card.");
        dealer.RevealHidden();
        isGameOver = true;
        modalLoss.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        doubleDownButton.gameObject.SetActive(false);
        //NewGame();
    }

    void TieGame()
    {
        Debug.Log("Tie game. Keep your money.");
        dealer.RevealHidden();
        isGameOver = true;
        modalTie.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        doubleDownButton.gameObject.SetActive(false);
        //NewGame();
    }

    [ContextMenu("Start New Game")]
    void NewGame()
    {
        doubleDown = false;
        isGameOver = false;
        modalWin.SetActive(false);
        modalLoss.SetActive(false);
        modalTie.SetActive(false);
        hitButton.gameObject.SetActive(true);
        standButton.gameObject.SetActive(true);
        doubleDownButton.gameObject.SetActive(true);
        dealer.ClearHand();
        player.ClearHand();
        // update UI
        DealInitialCards();
    }

    void DealInitialCards()
    {
        player.RequestHit(shoe.DealCard());
        dealer.RequestHit(shoe.DealCard());
        player.RequestHit(shoe.DealCard());
        dealer.RequestHit(shoe.DealCard());
        CheckInitialState();
    }

    void CheckInitialState()
    {
        if (!dealer.currentHand.isBlackjack && !player.currentHand.isBlackjack)
        {
            Debug.Log("Game can continue.");
        }
        else if (dealer.currentHand.isBlackjack && !player.currentHand.isBlackjack)
        {
            DealerWin();
        }
        else if (!dealer.currentHand.isBlackjack && player.currentHand.isBlackjack)
        {
            PlayerWin();
        }
        else
        {
            TieGame();
        }
    }

    void EvaluateHands()
    {
        if (player.currentHand.Total > dealer.currentHand.Total)
        {
            PlayerWin();
        }
        else if (player.currentHand.Total < dealer.currentHand.Total)
        {
            DealerWin();
        }
        else
        {
            TieGame();
        }
    }

    public void RequestDeal()
    {
        player.RequestHit(shoe.DealCard()); 
        if (player.currentHand.isBust)
        {
            DealerWin();
        }           
    }

    public void CheckDealerAction()
    {
        if (dealer.ShouldHit)
        {
            dealer.RequestHit(shoe.DealCard());
            if (dealer.currentHand.isBust)
            {
                PlayerWin();
            }
            else
            {
                CheckDealerAction();
            }
        }
        EvaluateHands();
    }
}
