using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class Hand
{
    public List<Card> Cards = new List<Card>();

    // Methods below 
    private int GetTotal()
    {
        int total = Cards.Sum(card => card.GetBlackjackValue());
        int aces = Cards.Count(card => card.Rank == Rank.Ace);

        while (total > 21 && aces > 0)
        {
            total -= 10;
            aces--;
        }
        return total;
    }

    public bool isBust => GetTotal() > 21;
    public bool isBlackjack => Cards.Count == 2 && GetTotal() == 21;
    public int Total => GetTotal();
    public int CardCount => Cards.Count;
}
