using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI handNumberText;
    private int handNumber;
    [SerializeField] private TextMeshProUGUI bankrollText;
    private int bankroll;
    [SerializeField] private TextMeshProUGUI netDifferenceText;
    private int netDifference;

    [SerializeField] private GameObject modalWin;
    [SerializeField] private GameObject modalLoss;
    [SerializeField] private GameObject modalTie;
    [SerializeField] private GameObject modalGameOver;
    [SerializeField] private Button hitButton;  
    [SerializeField] private Button standButton;  
    [SerializeField] private Button doubleDownButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()    // was originally Start
    {
        handNumber = 0;
        bankroll = 1000;
        netDifference = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        handNumberText.text = $"Hand: {handNumber}/30";
        bankrollText.text = $"Bank: ${bankroll}";
        if (netDifference < 0)
        {
            netDifferenceText.text = $"Net: -${Math.Abs(netDifference)}";
        }
        else
        {
            netDifferenceText.text = $"Net: +${netDifference}";
        }
    }

    void GameOver()
    {
        modalGameOver.SetActive(true);
    }

    void ShowModal(int modal)
    {
        switch (modal)
        {
            case 1: // player win
                modalWin.SetActive(true);
                break;
            case 2: // dealer win
                modalLoss.SetActive(true);
                break;
            case 3: // tie game
                modalTie.SetActive(true);
                break;
            default:
                break;
        }
    }

    void HideModal()
    {
        modalWin.SetActive(false);
        modalLoss.SetActive(false);
        modalTie.SetActive(false);
    }

    void ShowButtons()
    {
        hitButton.gameObject.SetActive(true);
        standButton.gameObject.SetActive(true);
        doubleDownButton.gameObject.SetActive(true);
    }

    void HideButtons()
    {
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        doubleDownButton.gameObject.SetActive(false);
    }

    void DisableButtons()
    {
        hitButton.interactable = false;
        standButton.interactable = false;
        doubleDownButton.interactable = false;
    }

    void EnableButtons()
    {
        hitButton.interactable = true;
        standButton.interactable = true;
        doubleDownButton.interactable = true;
    }

    public void UpdateStats(int money){ netDifference += money; bankroll += money; UpdateUI(); }
    public void NextRound() { handNumber += 1; UpdateUI(); }
    public void RequestShowModal(int modal) { ShowModal(modal); }
    public void RequestGameOver() { GameOver(); }
    public void RequestHideModal() { HideModal(); }
    public void RequestShowButtons() { ShowButtons(); }
    public void RequestHideButtons() { HideButtons(); }
    public void RequestEnableButtons() { EnableButtons(); }
    public void RequestDisableButtons() { DisableButtons(); }
    public int GetHandNumber => handNumber;
}
