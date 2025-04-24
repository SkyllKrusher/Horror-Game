using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    private CollectibleType itemType;
    private int holdingCount;
    private int maxStorage;

    protected virtual void TryUseItem(out bool isUsed)
    {
        if (holdingCount <= 0)
        {
            isUsed = false;
            return;
        }
        holdingCount--;
        isUsed = true;
    }
}
