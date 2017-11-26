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

    private AudioSource audioSource;
    [SerializeField] private AudioClip timeOverAudioClip;
    private bool wasTimerOverSoundPlayedOnce;


    void PlayTimeOverSound()
    {
        audioSource.Play();
        wasTimerOverSoundPlayedOnce = true;
    }


    void Start()
    {
        currentTime = _START_TIME_;
        textTime = GetComponent<Text>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = timeOverAudioClip;
        wasTimerOverSoundPlayedOnce = false;
    }

    void Update()
    {
        if (GameController.IsLevelCompleted)
            currentTime = _START_TIME_;
        else if (currentTime > 0)
        {
            //float currentTime = Time.time - startTime;
            currentTime -= Time.deltaTime;

//            int minutes = (int) (currentTime / 60);
//            int seconds = (int) (currentTime % 60);
//            int fraction = (int) ((currentTime * 100) % 100);

//            Timer = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
//            Timer = String.Format("{0:00}", currentTime);
            textTime.text = String.Format("{0:00}\"", currentTime);
        }
        else
        {
            if (!wasTimerOverSoundPlayedOnce)
                PlayTimeOverSound();
            GameController.IsGameOver = true;
        }
    }
}