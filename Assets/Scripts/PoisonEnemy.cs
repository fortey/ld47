using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEnemy : Enemy
{
    public int damage = 1;
    public float poisonTime = 5f;
    public float poisonTick = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onDead();
            collision.GetComponent<Character>().Poisoning(this);
            Destroy(gameObject);
        }
    }
}
