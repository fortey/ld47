using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Bullet;

    public float startTimeBtwShoots;

    float timeBtwShoots;
    void Start()
    {
        timeBtwShoots = startTimeBtwShoots;
    }


    void Update()
    {
        if (timeBtwShoots <= 0)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
