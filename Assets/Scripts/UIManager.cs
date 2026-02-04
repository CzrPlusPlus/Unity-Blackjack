using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI handNumberText;
    private int handNumber;
    [SerializeField] private TextMeshProUGUI bankrollText;
    private int bankroll;
    [SerializeField] private TextMeshProUGUI netDifferenceText;
    private int netDifference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handNumber = 0;
        bankroll = 1000;
        netDifference = 0;
        UpdateUI();
    }

    public void UpdateStats(int money)
    {
        netDifference += money;
        bankroll += money;
        UpdateUI();
    }

    public void NextRound() { handNumber += 1; UpdateUI(); }

    void UpdateUI()
    {
        handNumberText.text = $"Hand: {handNumber}/20";
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
}
