using UnityEngine;
using System.Collections.Generic;

public class Hand
{
    public List<Card> Cards = new List<Card>();

    public bool isBust => GetTotal() > 21;
    public bool isBlackjack => Cards.Count == 2 && GetTotal() == 21;
    public int Total => GetTotal();

    // Methods below 
    public int GetTotal()
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

    public int GetBlackjackValue()
    {
        if (Rank == Rank.Ace) return 11;
        if (Rank >= Rank.Jack) return 10;
        return (int)Rank;
    }
}
