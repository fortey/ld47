using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : Enemy
{
    public int damage = 3;
    public float lifeTime = 3f;
    public float radius = 2f;


    void Start()
    {
        StartCoroutine(Bang());
    }


    void Update()
    {

    }

    IEnumerator Bang()
    {
        yield return new WaitForSeconds(lifeTime);

        var character = GameObject.FindWithTag("Player");
        if (Vector2.Distance(transform.position, character.transform.position) < radius)
        {
            character.GetComponent<Character>().TakeDamage(damage);
        }
        //var cols = Physics2D.OverlapCircleAll(transform.position, radius);
        //foreach (var col in cols)
        //{
        //    if (col.CompareTag("Player"))
        //    {
        //        Debug.Log("dfd");
        //        col.GetComponent<Character>().TakeDamage(damage);
        //    }
        //    break;
        //}
        onDead();
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
