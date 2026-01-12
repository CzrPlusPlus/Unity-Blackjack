using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cardPrefabs;
    [SerializeField] private GameObject hiddenCard;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform dealerHand;
    private float leftCardX = -1f;
    private float leftCardY = -3f;
    private float leftCardZ = 0;
    private float rightCardX = 1f;
    private float rightCardY = -3f;
    private float rightCardZ = 0;
    private Vector3 leftSpawnPos;
    private Vector3 rightSpawnPos;
    private Vector3 thirdSpawnPos;
    private Vector3 fourthSpawnPos;
    private bool dealer = true; // will deal to the dealer first

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftSpawnPos = new Vector3(leftCardX, leftCardY, leftCardZ);
        rightSpawnPos = new Vector3(rightCardX, rightCardY, rightCardZ);
        thirdSpawnPos = new Vector3(rightCardX + 2f, rightCardY, rightCardZ);  // testing extra card spawns
        fourthSpawnPos = new Vector3(rightCardX + 3f, rightCardY, rightCardZ);  // testing extra card spawns
        // SpawnCardPrefab(leftSpawnPos, 0);
        // SpawnCardPrefab(rightSpawnPos, 1);
        SpawnCardPrefab(leftSpawnPos, 0, false);    // player's left card
        SpawnCardPrefab(rightSpawnPos, 1, false);   // player's right card
        SpawnExtraCard(thirdSpawnPos, 2, false);    // testing third card spawning
        SpawnExtraCard(fourthSpawnPos, 3, false);    // testing fourth card spawning
    }

    void SpawnCardPrefab(Vector3 spawnPos, int cardIndex, bool dealer)
    {
        //int cardIndex = 0; // ace of clubs
        //Vector3 spawnPos = new Vector3(cardX, cardY, cardZ);
        if (cardIndex == -1)
        {
            // instantiate hidden card
            return;
        }
        Instantiate(cardPrefabs[cardIndex], spawnPos, Quaternion.identity, playerHand);
    }

    void SpawnExtraCard(Vector3 spawnPos, int cardIndex, bool dealer)
    {
        Instantiate(cardPrefabs[cardIndex], spawnPos, Quaternion.identity, playerHand);
        playerHand.position += new Vector3(-1f, 0f, 0f);
    }
}
