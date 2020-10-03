using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 5f;

    private Rigidbody2D rb;

    private Vector2 screenRes;
    private float objectWidth;
    private float objectHeight;
    void Start()
    {
        screenRes = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        rb = GetComponent<Rigidbody2D>();

        transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));

        rb.velocity = transform.up * Speed;
    }

    void FixedUpdate()
    {
        if (-screenRes.x - objectWidth > transform.position.x || screenRes.x + objectWidth < transform.position.x
            || -screenRes.y - objectHeight > transform.position.y || screenRes.y + objectHeight < transform.position.y)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
