using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Dealer dealer;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private SessionTimer sessionTimer;
    [SerializeField] private TextMeshProUGUI playerTotalText;
    [SerializeField] private TextMeshProUGUI dealerTotalText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip lossSound;
    private Shoe shoe;
    private bool doubleDown = false;
    private bool isRoundOver = false;
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
        if (isRoundOver && Keyboard.current.spaceKey.wasPressedThisFrame)   // Checking for user input to start next hand
        {
            NewGame();
        }
        if (isGameOver && Keyboard.current.escapeKey.wasPressedThisFrame)   // checking for user input to return to main menu
        {
            SceneManager.LoadScene(0);
        }
    }

    void PlayerWin()
    {
        StopAllCoroutines();
        PlaySound();
        dealer.RevealHidden();
        dealerTotalText.text = "Current Total: " + dealer.currentHand.Total;
        isRoundOver = true;
        uiManager.RequestHideButtons();
        if (doubleDown)
        {
            uiManager.UpdateStats(50);  // +$50
        }
        else
        {
            uiManager.UpdateStats(25);  // +$25
        }
        
        if (uiManager.GetHandNumber >= 30)
        {
            isRoundOver = false;
            uiManager.RequestGameOver();
            isGameOver = true;
            sessionTimer.StopTimer();
        }
        else
        {
            uiManager.RequestShowModal(1);   // modal 1 = win modal
        }
    }

    void DealerWin()
    {
        StopAllCoroutines();
        PlaySound(false);
        dealer.RevealHidden();
        dealerTotalText.text = "Current Total: " + dealer.currentHand.Total;
        isRoundOver = true;
        uiManager.RequestHideButtons();
        if (doubleDown)
        {
            uiManager.UpdateStats(-50); // +$50
        }
        else
        {
            uiManager.UpdateStats(-25); // +$25
        }
        
        if (uiManager.GetHandNumber >= 30)
        {
            isRoundOver = false;
            uiManager.RequestGameOver();
            isGameOver = true;
            sessionTimer.StopTimer();
        }
        else
        {
            uiManager.RequestShowModal(2);  // modal 2 = loss modal 
        }   
    }

    void TieGame()
    {
        StopAllCoroutines();
        PlaySound();
        dealer.RevealHidden();
        dealerTotalText.text = "Current Total: " + dealer.currentHand.Total;
        isRoundOver = true;
        uiManager.RequestHideButtons();

        if (uiManager.GetHandNumber >= 30)
        {
            isRoundOver = false;
            uiManager.RequestGameOver();
            isGameOver = true;
            sessionTimer.StopTimer();
        }
        else
        {
            uiManager.RequestShowModal(3);   // modal 3 = tie modal
        }
    }

    void NewGame()
    {
        doubleDown = false;
        isRoundOver = false;
        uiManager.RequestHideModal();
        uiManager.RequestShowButtons();
        uiManager.RequestDisableButtons();
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
            uiManager.RequestEnableButtons();
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
            if (!isRoundOver)
            {
                EvaluateHands();   
            }
        }
    }

    void PlaySound(bool win = true)
    {
        if (win)
        {
            audioSource.PlayOneShot(winSound);
        }
        else
        {
            audioSource.PlayOneShot(lossSound);
        }
    }
}
