using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLabal : MonoBehaviour
{
    public GameObject Good;
    public GameObject Bad;

    void Start()
    {

    }

    public void ShowBad()
    {
        Good.SetActive(true);
        StartCoroutine(HideLevelLabel());
    }

    private IEnumerator HideLevelLabel()
    {
        yield return new WaitForSeconds(1);
        Good.SetActive(false);
        Bad.SetActive(false);
    }
}
