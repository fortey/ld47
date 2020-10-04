using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI LevelLabel;
    public string LevelName;
    public string NextScene;

    void Start()
    {
        LevelLabel.text = LevelName;
        LevelLabel.gameObject.SetActive(true);
        StartCoroutine(HideLevelLabel());

        var character = GameObject.FindGameObjectWithTag("Player");
        character.GetComponent<Character>().onDead += () => SceneManager.LoadScene(NextScene);
    }

    private IEnumerator HideLevelLabel()
    {
        yield return new WaitForSeconds(1);
        LevelLabel.gameObject.SetActive(false);
    }


}
