using UnityEngine;
using Ilumisoft.HealthSystem;

public class PlayerHealthPickup : MonoBehaviour
{
    public HealthComponent healthComponent;
    public float healthIncreasePercent = 0.2f; // 20%

    void Start()
    {
        if (healthComponent == null)
        {
            healthComponent = GetComponent<HealthComponent>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruit") && healthComponent != null && healthComponent.IsAlive)
        {
            Debug.Log("Updating health bar: " + healthComponent.CurrentHealth);
            healthComponent.AddHealth(healthComponent.MaxHealth * healthIncreasePercent);
            Debug.Log("Updating health bar: " + healthComponent.CurrentHealth);
            Destroy(other.gameObject); // Remove fruit from game
        }
    }
}
