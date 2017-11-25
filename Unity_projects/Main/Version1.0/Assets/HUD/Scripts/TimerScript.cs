using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private static String Timer;

    [SerializeField] private float _START_TIME_ = 10f;
    private float currentTime;
    private Text textTime;

    //void Awake()
    //{
    //    startTime = Time.time;
    //}

    void Start()
    {
        currentTime = _START_TIME_;
        textTime = GetComponent<Text>();
    }

    void Update()
    {
        if (GameController.IsLevelCompleted)
            currentTime = _START_TIME_;
        else if (currentTime > 0)
        {
            //float currentTime = Time.time - startTime;
            currentTime -= Time.deltaTime;

            int minutes = (int) (currentTime / 60);
            int seconds = (int) (currentTime % 60);
            int fraction = (int) ((currentTime * 100) % 100);

            Timer = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
            textTime.text = Timer;
        }
        else
            GameController.IsGameOver = true;
    }
}