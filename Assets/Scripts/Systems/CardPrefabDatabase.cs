using UnityEngine;
using System.Collections.Generic;

public class CardPrefabDatabase : MonoBehaviour
{
    public static CardPrefabDatabase Instance;

    [SerializeField] private List<CardPrefabEntry> cardPrefabs;
    private Dictionary<(Suit, Rank), GameObject> lookup;

    private void Awake()
    {
        Instance = this;
        BuildLookup();
    }

    private void BuildLookup()
    {
        lookup = new Dictionary<(Suit, Rank), GameObject>();

        foreach (var entry in cardPrefabs)
        {
            lookup[(entry.Suit, entry.Rank)] = entry.Prefab;
        }
    }

    public GameObject GetPrefab(Card card)
    {
        return lookup[(card.Suit, card.Rank)];
    }
}
