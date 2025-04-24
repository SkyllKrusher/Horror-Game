using UnityEngine;

public class Collectible : MonoBehaviour, ICollectible
{
    public virtual void Collect()
    {
        throw new System.NotImplementedException();
    }
}
