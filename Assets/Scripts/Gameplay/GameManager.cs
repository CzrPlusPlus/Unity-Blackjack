using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject hiddenCard;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform dealerHand;
    private bool firstCardsDealt = false;
}
