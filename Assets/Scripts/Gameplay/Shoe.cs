using UnityEngine;
using System.Collections.Generic;

public class Shoe : MonoBehaviour
{
    List<Card> shoe = new List<Card>();

    void BuildShoe()    // this function builds a 6-deck shoe
    {
        shoe.Clear();   // assuming this is a method for List

        for (int i = 0; i < 6; i++)
        {
            foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in System.Enum.GetValues(typeof(Rank)))
                {
                    shoe.Add(new Card(suit, rank));
                }
            }
        }
    }

    void ShuffleShoe()  // Fisher-Yates shuffle
    {
        for (int i = shoe.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (shoe[i], shoe[j]) = (shoe[j], shoe[i]);
        }
    }

    Card DealCard()     // returns a Card (suit & rank)
    {
        Card card = shoe[0];
        shoe.RemoveAt(0);
        return card;
    }
}
