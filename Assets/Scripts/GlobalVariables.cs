using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables instance = null;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            if (OnScoreChanged != null)
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
}
