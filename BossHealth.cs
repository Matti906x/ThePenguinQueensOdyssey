using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] int health, maxHealth = 400;

    [SerializeField] FloatingHealthBar healthBar;

    void Awake() 
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    void Start() 
    {
        healthBar.UpdateHealthBar(health, maxHealth);
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
