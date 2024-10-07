using UnityEngine;
using System;
using System.Collections.Generic;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private List<string> damagingTags = new List<string>();
    
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get { return maxHealth; } }

    public event Action DamageTaken; 

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleDamage(other);
    }

    private void HandleDamage(Collider2D other)
    {
        var validTag = damagingTags.Contains(other.gameObject.tag);
        if (!validTag)
        {
            return;
        }
        
        // TODO: Implement Damager/projectile/ect. handling
    }

    private void TakeDamage(int damageAmount)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - damageAmount);
        SafeEventHandler.SafelyBroadcastAction(ref DamageTaken);
    }
}