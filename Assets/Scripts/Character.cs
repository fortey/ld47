using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public HealthBar healthBar;
    public int startHealth = 5;
    [SerializeField]
    private int maxHealth = 10;

    private int health = 5;
    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            ShowHealth();
        }
    }
    void Start()
    {
        Health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShowHealth()
    {
        healthBar.OnHealthChanged((float)health / maxHealth);
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health == 0)
        {

        }
    }
}
