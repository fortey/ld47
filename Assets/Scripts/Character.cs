using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public HealthBar healthBar;
    public Animator anim;
    public int startHealth = 5;
    [SerializeField]
    private int maxHealth = 10;

    private int health = 5;

    private float poisonTime;
    private float poisonTick;
    private float currentPoisonTime;
    private int poisonDamage;

    private SpriteRenderer spriteRenderer;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdatePoisoning();
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

    public void Poisoning(PoisonEnemy enemy)
    {
        poisonTime = enemy.poisonTime;
        poisonTick = enemy.poisonTick;
        poisonDamage = enemy.damage;
        spriteRenderer.color = Color.green;
    }

    private void UpdatePoisoning()
    {
        if (poisonTime >= poisonTick)
        {
            currentPoisonTime += Time.deltaTime;
            if (currentPoisonTime >= poisonTick)
            {
                poisonTime -= currentPoisonTime;
                TakeDamage(poisonDamage);
                currentPoisonTime = 0f;
                if (poisonTime < poisonTick)
                {
                    spriteRenderer.color = Color.white;
                }
            }
        }
    }
}
