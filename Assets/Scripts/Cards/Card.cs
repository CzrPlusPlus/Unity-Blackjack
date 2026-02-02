public class Card
{
    public Suit Suit;
    public Rank Rank;

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public int GetBlackjackValue()
    {
        if (Rank == Rank.Ace) return 11;
        if (Rank >= Rank.Jack) return 10;
        return (int)Rank;
    }
}
