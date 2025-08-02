using UnityEngine;
using UnityEngine.UI;
using Ilumisoft.HealthSystem;

public class HealthBarUI : MonoBehaviour
{
    public HealthComponent playerHealth;
    public Slider healthSlider;  // Assign in Inspector

    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<HealthComponent>();
        }

        if (healthSlider == null)
        {
            healthSlider = GetComponent<Slider>();
        }
        
        // Initialize slider before subscribing to avoid incorrect start values
        healthSlider.maxValue = playerHealth.MaxHealth;
        healthSlider.value = playerHealth.CurrentHealth;

        // Subscribe to changes
        playerHealth.OnHealthChanged += OnHealthChanged;
    }

    void OnHealthChanged(float changeAmount)
    {
        // Update the slider value based on current health
        healthSlider.value = playerHealth.CurrentHealth;
        Debug.Log("Updating health bar UI: " + healthSlider.value);
    }

    void OnDestroy()
    {
        if (playerHealth != null)
            playerHealth.OnHealthChanged -= OnHealthChanged;
    }
}
