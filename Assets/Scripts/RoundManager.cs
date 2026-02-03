using UnityEngine;

public class RoundManager 
{
    private int handNumber;
    private int moneyInBank;
    private int netDifference;

    public RoundManager()
    {
        handNumber = 1;
        moneyInBank = 1000;
        netDifference = 0;
    }

    // public void NextRound()
    // {
    //     handNumber += 1;
    //     NextRound?.Invoke();
    //     Debug.Log("Current Turn Count: " + handNumber);  
    //     // time elapsed should be increasing the entire time
    //     // moneyInBank will be +/- depending on win or loss
    //     // netDifference will be +/- depending on win or loss
    // }
}
