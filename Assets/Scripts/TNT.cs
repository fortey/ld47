using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TNT : MonoBehaviour
{
    public Sprite Explosion;
    public float newSpeed = 2f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharController>().moveSpeed = newSpeed;
            transform.SetParent(collision.transform);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            transform.SetParent(null);
            GetComponent<SpriteRenderer>().sprite = Explosion;
            Destroy(collision.gameObject);
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(GlobalVariables.instance.CurrentScene());
    }
}
