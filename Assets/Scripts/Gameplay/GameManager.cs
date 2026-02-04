using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

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
    [SerializeField] private TextMeshProUGUI playerTotalText;
    [SerializeField] private TextMeshProUGUI dealerTotalText;
    private Shoe shoe;
    private bool doubleDown = false;
    private bool isGameOver = false;

    void Awake()
    {
        shoe = new Shoe();
    }

    void Start()
    {
        shoe.Initialize();
        NewGame();
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
        StopAllCoroutines();
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
        StopAllCoroutines();
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
        StopAllCoroutines();
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
        // Debug.Log("Number of cards in the shoe: " + shoe.CardCount);
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
        StartCoroutine(DealInitialCards());
    }

    IEnumerator DealInitialCards()
    {
        // player card 1
        player.RequestHit(shoe.DealCard());
        playerTotalText.text = "Current Total: " + player.currentHand.Total;
        yield return new WaitForSeconds(0.5f);

        // dealer card 1
        dealer.RequestHit(shoe.DealCard());
        yield return new WaitForSeconds(0.5f);

        // player card 2
        player.RequestHit(shoe.DealCard());
        playerTotalText.text = "Current Total: " + player.currentHand.Total;
        yield return new WaitForSeconds(0.5f);

        // dealer card 2
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
        else if (player.currentHand.Total == 21)
        {
            CheckDealerAction();
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
        else
        {
            EvaluateHands();
        }
    }
}
