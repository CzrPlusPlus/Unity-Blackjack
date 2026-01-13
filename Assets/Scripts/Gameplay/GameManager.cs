using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject hiddenCard;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform dealerHand;
    private float leftCardX = -1f;
    private float leftCardY = -3f;
    private float leftCardZ = 0;
    private float rightCardX = 1f;
    private float rightCardY = -3f;
    private float rightCardZ = 0;
    private bool firstCardsDealt = false;
}
