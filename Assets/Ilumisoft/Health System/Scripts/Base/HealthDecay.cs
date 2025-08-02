using UnityEngine;
using Ilumisoft.HealthSystem;

public class HealthDecay : MonoBehaviour
{
    public HealthComponent healthComponent;
    public float decayPercent = 0.05f;

    void Start()
    {
        if (healthComponent == null)
        {
            healthComponent = GetComponent<HealthComponent>();
        }
        StartCoroutine(ReduceHealthEverySecond());
    }

    System.Collections.IEnumerator ReduceHealthEverySecond()
    {
        while (true)
        {
            if (healthComponent != null && healthComponent.CurrentHealth > 0)
            {
                float damageAmount = healthComponent.MaxHealth * decayPercent;
                healthComponent.ApplyDamage(damageAmount);
            }
            yield return new WaitForSeconds(1f);    
        }
    }

}
