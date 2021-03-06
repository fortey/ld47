﻿using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float StartTime;
    public Text time;
    private float newtime;
    // Start is called before the first frame update
    void Start()
    {
        time.text = StartTime.ToString();
        newtime = StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartTime -= Time.deltaTime;

        if (StartTime < 0 && newtime != 0)
        {
            StartTime = newtime - 5;
            time.text = StartTime.ToString();
            newtime = StartTime;
        }
        else if (newtime != 0)
            time.text = StartTime.ToString("#");
    }

    public void AddTime(float additionalTime)
    {
        StartTime += additionalTime;
    }
}
