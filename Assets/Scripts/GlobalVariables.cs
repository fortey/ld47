using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables instance = null;

    public List<String> Scenes;
    private int currentIndex;
    public String NextScene;

    public int Score
    {
        get => score;
        set
        {
            score = value < 0 ? 0 : value;
            if (score == 3)
            {
                NextScene = "Special";
                score = 0;
            }
            OnScoreChanged.Invoke(score);
        }
    }
    public Action<int> OnScoreChanged;

    private int score;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetNext()
    {
        currentIndex++;
        NextScene = Scenes[currentIndex];
    }

    public string PreviousScene()
    {
        return Scenes[currentIndex - 1];
    }

    public string CurrentScene()
    {
        return Scenes[currentIndex];
    }
}
