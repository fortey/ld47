using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Enemy
{
    public float AddedTime = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onDead();

            Destroy(gameObject);
        }
    }
}
