using System;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private InventoryItemUI inventoryItemUI;
    [SerializeField]
    private int holdingCount;
    [SerializeField]
    private int maxStorage;
    [SerializeField]
    private CollectibleType itemType;
    public CollectibleType ItemType => itemType;
    public virtual void TryUseItem(out bool isUsed)
    {
        if (holdingCount <= 0)
        {
            isUsed = false;
            holdingCount = 0;
            return;
        }
        holdingCount--;
        isUsed = true;
        inventoryItemUI.SetItemUI(holdingCount);
    }

    public virtual void TryAddItem(out bool isAddedSuccessfully)
    {
        if (holdingCount >= maxStorage)
        {
            isAddedSuccessfully = false;
            holdingCount = maxStorage;
            return;
        }
        holdingCount++;
        isAddedSuccessfully = true;
    }
}