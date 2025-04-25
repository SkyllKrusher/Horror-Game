using System;
using UnityEngine;

public enum CollectibleType
{
    Battery,
    Meds,
    Food
}

public class Collectibles : MonoBehaviour, ICollectible
{
    public int IncrementValue = 0;
    public CollectibleType ItemType;
    public static event Action<int, CollectibleType> OnCollectiblesCollected;
    public void Collect()
    {
        Debug.Log($"Hi You Have Collected {ItemType}");
        OnCollectiblesCollected?.Invoke(IncrementValue, ItemType);
        Destroy(gameObject);
    }
}
