public enum Suit { Hearts, Diamonds, Clubs, Spades }
public enum Rank { Ace = 11, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

public class Card
{
    public Suit Suit;
    public Rank Rank;

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }
}
