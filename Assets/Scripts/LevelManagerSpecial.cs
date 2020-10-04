using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerSpecial : MonoBehaviour
{
    public TextMeshProUGUI LevelLabel;
    public string LevelName;
    public string NextScene;

    void Start()
    {
        LevelLabel.text = LevelName;
        LevelLabel.gameObject.SetActive(true);
        StartCoroutine(HideLevelLabel());

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
                //GlobalVariables.instance.SetNext();
                //GlobalVariables.instance.Score++;
                SceneManager.LoadScene(GlobalVariables.instance.NextScene);
            }

        }
        else
        {
            if (GlobalVariables.instance)
            {
                //GlobalVariables.instance.Score--;
                var tnt = GameObject.FindObjectOfType<TNT>();
                GlobalVariables.instance.tntPos = tnt.transform.position;
                SceneManager.LoadScene(GlobalVariables.instance.PreviousScene());
            }
        }
    }
}
