using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health=10;
    public int currenthealth {get; private set;}
    public int maxhealth {get; private set;}
    public static Action<int> OnPlayerTakeDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        currenthealth=health;
        maxhealth=health;
    }

    public void TakeDamage(int damageAmount){
        currenthealth-=damageAmount;
        OnPlayerTakeDamage?.Invoke(currenthealth);
        if(currenthealth<=0){
            Destroy(gameObject);
        }
    }
}
