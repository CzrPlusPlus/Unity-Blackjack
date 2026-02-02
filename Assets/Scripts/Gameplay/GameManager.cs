using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject hiddenCard;
    [SerializeField] private Player player;
    [SerializeField] private Dealer dealer;
    private bool firstCardsDealt = false;

    void Start()
    {
        DealInitialCards();
    }

    void DealInitialCards()
    {
        dealer.RequestHit();
        player.OnHitButton();
    }
}
