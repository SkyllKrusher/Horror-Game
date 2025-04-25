using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private static InventoryController _instance;
    public static InventoryController Instance => _instance;

    [SerializeField]
    private List<InventoryItem> inventoryItems;
    private Dictionary<CollectibleType, InventoryItem> collectibles;
    public Dictionary<CollectibleType, InventoryItem> Collectibles => collectibles;

    private void Start()
    {
        collectibles = new Dictionary<CollectibleType, InventoryItem>();
        foreach (InventoryItem inventoryItem in inventoryItems)
        {
            collectibles.Add(inventoryItem.ItemType, inventoryItem);
        }
    }
    public void CollectItem(CollectibleType type)
    {
        // collectibles[type].
        bool isAddedSuccessfully = false;
        collectibles[type].TryAddItem(out isAddedSuccessfully);
    }
}
