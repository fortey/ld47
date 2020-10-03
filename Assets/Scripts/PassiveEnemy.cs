using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEnemy : Enemy
{
    public int damage = 3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onDead();
            collision.GetComponent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
