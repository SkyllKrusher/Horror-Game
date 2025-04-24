using UnityEngine;

public class HealthInventoryItem : InventoryItem
{
    [SerializeField]
    private float healPoints = 30f;
    private PlayerData playerData;
    protected override void TryUseItem(out bool isUsed)
    {
        base.TryUseItem(out isUsed);
        if (isUsed)
        {
            Heal();
        }
    }

    private void Heal()
    {
        playerData.Heal(healPoints);
    }
}
