using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private PlayerData _instance;
    private GameUI gameUI;
    public PlayerData Instance => _instance;

    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private float startHealth = 70f;
    private float currentHealth;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        gameUI = FindFirstObjectByType<GameUI>();
        currentHealth = startHealth;
        gameUI.SetHealthUI(currentHealth);
    }

    public void Heal(float healPoints)
    {
        // if (currentHealth == maxHealth)
        //     return;
        currentHealth += healPoints;
        if (currentHealth > maxHealth)
            gameUI.SetHealthUI(currentHealth);
    }

    public void Damage(float damagePoints)
    {
        currentHealth -= damagePoints;
        if (currentHealth <= 0)
        {
            Debug.Log("DIED!"); //implement death
        }
    }
}
