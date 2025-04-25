using UnityEngine;

public class Collectible : MonoBehaviour, ICollectible
{
    CollectibleType collectibleType;
    public virtual void Collect()
    {
        InventoryController.Instance.CollectItem(collectibleType);
    }
}
