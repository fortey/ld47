using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject passiveEnemy;
    public float passiveEnemyTime = 1f;
    public int passiveEnemyMaxCount = 3;
    private int passiveEnemyCount;

    public GameObject explosiveEnemy;
    public float explosiveEnemyTime = 1f;
    public int explosiveEnemyMaxCount = 3;
    private int explosiveEnemyCount;

    public GameObject poisonEnemy;
    public float poisonEnemyTime = 1f;
    public int poisonEnemyMaxCount = 2;
    private int poisonEnemyCount;

    public GameObject clock;
    public float clockTime = 1f;
    public int clockMaxCount = 2;
    private int clockCount;

    private Vector2 screenRes;

    private void Start()
    {
        screenRes = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine(Spawn(passiveEnemyTime, () => passiveEnemyCount < passiveEnemyMaxCount, SpawnPassive));
        StartCoroutine(Spawn(explosiveEnemyTime, () => explosiveEnemyCount < explosiveEnemyMaxCount, SpawnExplosive));
        StartCoroutine(Spawn(poisonEnemyTime, () => poisonEnemyCount < poisonEnemyMaxCount, SpawnPoison));
        StartCoroutine(Spawn(clockTime, () => clockCount < clockMaxCount, SpawnClock));
    }

    private IEnumerator Spawn(float time, Func<bool> canSpawn, Action<Vector3> SpawnAction)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (canSpawn())
            {
                var x = UnityEngine.Random.Range(-screenRes.x, screenRes.x);
                var y = UnityEngine.Random.Range(-screenRes.y, screenRes.y);
                while (Physics2D.OverlapBox(new Vector2(x, y), new Vector2(1, 1), 0f) != null)
                {
                    x = UnityEngine.Random.Range(-screenRes.x, screenRes.x);
                    y = UnityEngine.Random.Range(-screenRes.y, screenRes.y);
                }
                SpawnAction(new Vector3(x, y, 0));

            }
        }
    }

    private void onPassiveDead()
    {
        passiveEnemyCount--;
    }

    private void onExplosiveDead()
    {
        explosiveEnemyCount--;
    }

    private void SpawnExplosive(Vector3 pos)
    {
        var enemy = Instantiate(explosiveEnemy, pos, Quaternion.identity);
        explosiveEnemyCount++;
        enemy.GetComponent<Enemy>().onDead = onExplosiveDead;
    }

    private void SpawnPassive(Vector3 pos)
    {
        var enemy = Instantiate(passiveEnemy, pos, Quaternion.identity);
        passiveEnemyCount++;
        enemy.GetComponent<Enemy>().onDead = onPassiveDead;
    }

    private void SpawnPoison(Vector3 pos)
    {
        var enemy = Instantiate(poisonEnemy, pos, Quaternion.identity);
        poisonEnemyCount++;
        enemy.GetComponent<Enemy>().onDead = () => poisonEnemyCount--;
    }

    private void SpawnClock(Vector3 pos)
    {
        var enemy = Instantiate(clock, pos, Quaternion.identity);
        clockCount++;
        enemy.GetComponent<Enemy>().onDead = () => clockCount--;
    }
}
