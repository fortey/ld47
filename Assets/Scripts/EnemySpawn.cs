using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject passiveEnemy;
    public float passiveEnemyTime = 1f;

    private Vector2 screenRes;

    private void Start()
    {
        screenRes = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(Spawn(passiveEnemy));
    }

    private IEnumerator Spawn(GameObject enemy)
    {
        while (true)
        {
            yield return new WaitForSeconds(passiveEnemyTime);
            var x = Random.Range(-screenRes.x, screenRes.x);
            var y = Random.Range(-screenRes.y, screenRes.y);

            Instantiate(passiveEnemy, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
