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

    LevelLabal label;

    void Start()
    {
        LevelLabel.text = LevelName;
        //LevelLabel.gameObject.SetActive(true);
        //StartCoroutine(HideLevelLabel());
        label = GameObject.FindObjectOfType<LevelLabal>();

        var character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        character.onDead += () => EndLevel(character);
    }

    private IEnumerator HideLevelLabel()
    {
        yield return new WaitForSeconds(1);
        LevelLabel.gameObject.SetActive(false);
    }

    public void EndLevel(Character character)
    {
        if (character.Health == 0)
        {
            if (GlobalVariables.instance)
            {
                StartCoroutine(SwitchLevelGood());
            }

        }
        else
        {
            StartCoroutine(SwitchLevelBad());
        }
    }

    private IEnumerator SwitchLevelGood()
    {
        label.Good.SetActive(true);
        yield return new WaitForSeconds(1);
        GlobalVariables.instance.SetNext();
        GlobalVariables.instance.Score++;
        SceneManager.LoadScene(GlobalVariables.instance.NextScene);
    }

    private IEnumerator SwitchLevelBad()
    {
        label.Bad.SetActive(true);
        yield return new WaitForSeconds(1);
        if (GlobalVariables.instance)
            GlobalVariables.instance.Score--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
