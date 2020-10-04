using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Enemy
{
    public float AdditionalTime = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onDead();
            GameObject.FindGameObjectWithTag("Timer").SendMessage("AddTime", AdditionalTime);
            Destroy(gameObject);
        }
    }
}
