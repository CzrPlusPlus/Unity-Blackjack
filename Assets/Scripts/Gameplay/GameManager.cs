using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Dealer dealer;
    [SerializeField] private UIManager uiManager;
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
        dealerTotalText.text = "Current Total: " + dealer.currentHand.Total;
        isGameOver = true;
        modalWin.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        doubleDownButton.gameObject.SetActive(false);
        if (doubleDown)
        {
            // +$50
            uiManager.UpdateStats(50);
        }
        else
        {
            // +$25
            uiManager.UpdateStats(25);
        }
        // update
    }

    void DealerWin()
    {
        StopAllCoroutines();
        dealer.RevealHidden();
        dealerTotalText.text = "Current Total: " + dealer.currentHand.Total;
        isGameOver = true;
        modalLoss.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        doubleDownButton.gameObject.SetActive(false);
        if (doubleDown)
        {
            // +$50
            uiManager.UpdateStats(-50);
        }
        else
        {
            // +$25
            uiManager.UpdateStats(-25);
        }
    }

    void TieGame()
    {
        StopAllCoroutines();
        dealer.RevealHidden();
        dealerTotalText.text = "Current Total: " + dealer.currentHand.Total;
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
        playerTotalText.text = "Current Total: 0";
        dealerTotalText.text = "Current Total: ?";
        uiManager.NextRound();
        StartCoroutine(DealInitialCards());
    }

    IEnumerator DealInitialCards()
    {
        // player card 1
        yield return new WaitForSeconds(0.5f);
        player.RequestHit(shoe.DealCard());
        playerTotalText.text = "Current Total: " + player.currentHand.Total;

        // dealer card 1
        yield return new WaitForSeconds(0.5f);
        dealer.RequestHit(shoe.DealCard());

        // player card 2
        yield return new WaitForSeconds(0.5f);
        player.RequestHit(shoe.DealCard());
        playerTotalText.text = "Current Total: " + player.currentHand.Total;

        // dealer card 2
        yield return new WaitForSeconds(0.5f);
        dealer.RequestHit(shoe.DealCard());
        CheckInitialState();
    }

    void CheckInitialState()
    {
        if (!dealer.currentHand.isBlackjack && !player.currentHand.isBlackjack)
        {
            // Await Player Action
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

    public void RequestDeal(bool playerDoubleDown = false)
    {
        doubleDown = playerDoubleDown ? true : false;
        player.RequestHit(shoe.DealCard()); 
        playerTotalText.text = "Current Total: " + player.currentHand.Total;
        if (player.currentHand.isBust)
        {
            DealerWin();
        }
        else if (player.currentHand.Total == 21 || doubleDown)
        {
            player.OnStandButton();
        }         
    }

    public IEnumerator CheckDealerAction()
    {
        dealer.RevealHidden();
        if (dealer.ShouldHit)
        {
            dealer.RequestHit(shoe.DealCard());
            dealerTotalText.text = "Current Total: " + dealer.currentHand.Total;
            if (dealer.currentHand.isBust)
            {
                PlayerWin();
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(CheckDealerAction());
            }
        }
        else
        {
            if (!isGameOver)
            {
                EvaluateHands();   
            }
        }
    }
}
