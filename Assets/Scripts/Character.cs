﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public System.Action onDead;

    public HealthBar healthBar;
    public Animator anim;
    public int startHealth = 5;
    [SerializeField]
    private int maxHealth = 10;

    private int health = 5;

    private int poisonCount;

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
            onDead.Invoke();
        }
    }

    public void Poisoning(PoisonEnemy enemy)
    {
        poisonCount++;
        spriteRenderer.color = Color.green;
        StartCoroutine(PoisonAction(enemy));
    }

    private IEnumerator PoisonAction(PoisonEnemy enemy)
    {
        var poisonTime = enemy.poisonTime;
        var poisonTick = enemy.poisonTick;
        var poisonDamage = enemy.damage;
        while (poisonTime >= poisonTick)
        {
            yield return new WaitForSeconds(poisonTick);

            poisonTime -= poisonTick;
            TakeDamage(poisonDamage);
            if (poisonTime < poisonTick)
            {
                poisonCount--;
                if (poisonCount == 0)
                    spriteRenderer.color = Color.white;
            }
        }
    }
}
