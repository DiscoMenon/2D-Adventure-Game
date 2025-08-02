using UnityEngine;
using Ilumisoft.HealthSystem;

public class HealthRegen : MonoBehaviour
{
    public float healthIncreasePercent = 0.2f; // 20%

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruit")){
        HealthComponent health = other.GetComponent<HealthComponent>();
        if (health != null && health.IsAlive)
        {
            Debug.Log($"Health before: {health.CurrentHealth}");
            health.AddHealth(health.MaxHealth * healthIncreasePercent);
            Debug.Log($"Health after: {health.CurrentHealth}");
            Destroy(gameObject);
        }
        }
    }
}
