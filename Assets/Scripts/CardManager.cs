using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cardPrefabs;
    [SerializeField] private GameObject hiddenCard;
    private float leftCardX = -1f;
    private float leftCardY = -3f;
    private float leftCardZ = 0;
    private float rightCardX = 1f;
    private float rightCardY = -3f;
    private float rightCardZ = 0;
    private Vector3 leftSpawnPos;
    private Vector3 rightSpawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftSpawnPos = new Vector3(leftCardX, leftCardY, leftCardZ);
        rightSpawnPos = new Vector3(rightCardX, rightCardY, rightCardZ);
        SpawnCardPrefab(leftSpawnPos, 0);
        SpawnCardPrefab(rightSpawnPos, 1);
    }

    void SpawnCardPrefab(Vector3 spawnPos, int cardIndex)
    {
        //int cardIndex = 0; // ace of clubs
        //Vector3 spawnPos = new Vector3(cardX, cardY, cardZ);
        if (cardIndex == -1)
        {
            // instantiate hidden card
            return;
        }
        Instantiate(cardPrefabs[cardIndex], spawnPos, cardPrefabs[cardIndex].transform.rotation);
    }
}
