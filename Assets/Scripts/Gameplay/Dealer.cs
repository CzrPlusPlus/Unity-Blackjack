using UnityEngine;

public class Dealer : Agent
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject hiddenCard;
    private GameObject hiddenPrefab;
    private float leftCardX = -1f;
    private float leftCardY = 3f;
    private float leftCardZ = 0;
    private float rightCardX = 1f;
    private float rightCardY = 3f;
    private float rightCardZ = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // to do
    }

    protected override void Hit(Card card)
    {
        GameObject newCard = CardPrefabDatabase.Instance.GetPrefab(card);

        switch (currentHand.CardCount)
        {
            case 0: 
                currentHand.AddCardToHand(card);
                Vector3 leftCardPos = new Vector3(leftCardX, leftCardY, leftCardZ);
                hiddenPrefab = SpawnCardPrefab(hiddenCard, leftCardPos, transform);
                SpawnCardPrefab(newCard, leftCardPos, transform);
                break;
            case 1:
                currentHand.AddCardToHand(card);
                Vector3 rightCardPos = new Vector3(rightCardX, rightCardY, rightCardZ);
                SpawnCardPrefab(newCard, rightCardPos, transform);
                break;
            default:
                Debug.Log("Getting extra card now");
                currentHand.AddCardToHand(card);
                break;
        }
    }

    protected override void Stand()
    {
        Debug.Log("I am the dealer and I want to stand!");
    }

    public void RequestHit(Card card)
    {
        Hit(card);
    }

    public void RequestStand()
    {
        Stand();
    }

    [ContextMenu("Destroy Hidden Card")]
    private void TestDestroy()
    {
        if (hiddenPrefab != null)
        {
            Debug.Log("Destroying hidden card prefab.");
            Destroy(hiddenPrefab);
            hiddenPrefab = null; // Clear reference
        }
        else
        {
            Debug.LogWarning("hiddenPrefab is null, nothing to destroy.");
        }
    }
}
