﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    private static GhostGenerator ghostGeneratorInstance = null;

    [SerializeField] private GameObject ghostPrefab;
    private List<Ghost> ghostList;
    private Ghost currentGhost;

    [SerializeField] private GameObject player;
    [SerializeField] private bool isLevelCompleted;

    [SerializeField] private float _TIMER_RECORD_GHOST_TRANSFORM_ = 0.5f; //const ?
    private float timerRecordGhostTransform;


    //___________________________________________
    //singleton
    public GhostGenerator()
    {
    }

    public static GhostGenerator GhostGeneratorInstance
    {
        get
        {
            if (ghostGeneratorInstance == null)
            {
                ghostGeneratorInstance = new GhostGenerator();
            }
            return ghostGeneratorInstance;
        }
    }


    //____________________________________________

    private String ghostListToString()
    {
        String result = "";
        foreach (Ghost ghost in ghostList)
        {
            result += ghost.ToString() + "||";
        }
        return base.ToString() + result;
    }


    private void generateGhost()
    {
        if (ghostList.Count > 0)
        {
            foreach (Ghost ghost in ghostList)
            {
                Instantiate(ghostPrefab, ghost.getPositionVector(0), ghost.GetRotationQuaternion(0));
            }
        }
    }


    void Start()
    {
        isLevelCompleted = false;
        currentGhost = new Ghost();
        ghostList = new List<Ghost>();
        Debug.Log("player: " + player);
        timerRecordGhostTransform = _TIMER_RECORD_GHOST_TRANSFORM_;
    }


    private void LevelCompleted()
    {
        ghostList.Add(currentGhost);
    }
    

    private void RestartLevel()
    {
        isLevelCompleted = false;
        generateGhost();
    }


    void Update()
    {
        if (isLevelCompleted)
        {
            LevelCompleted();
            RestartLevel();
        }
        else
        {
            timerRecordGhostTransform -= Time.deltaTime;
            if (timerRecordGhostTransform <= 0)
            {
                currentGhost.addTransformData(player.transform);
                Debug.Log("currentGhost: " + currentGhost.ToString());
                Debug.Log("ghostList: " + ghostListToString());

                //            Debug.Log("currentGhostData getPositionVector: " + currentGhost.getPositionVector(0));
                Debug.Log("Time.deltaTime: " + Time.time);
                timerRecordGhostTransform = _TIMER_RECORD_GHOST_TRANSFORM_;
            }
        }
    }
}