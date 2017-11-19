using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : MonoBehaviour
{
    private static GhostGenerator ghostGeneratorInstance = null;

    [SerializeField] private GameObject ghostPrefab;
    private List<Ghost> ghostList;
    [SerializeField] private int ghostList_nextGhostIndex;
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

    public static GhostGenerator GetGhostGeneratorInstance
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

    public float TimerRecordGhostTransform
    {
        get { return _TIMER_RECORD_GHOST_TRANSFORM_; }
        set { _TIMER_RECORD_GHOST_TRANSFORM_ = value; }
    }

    private String ghostListToString()
    {
        String result = "";
        foreach (Ghost ghost in ghostList)
        {
            result += ghost.ToString() + "||";
        }
        return base.ToString() + result;
    }


    private void generateNextGhost()
    {
        if (ghostList.Count > 0)
        {
            GameObject newGhost = Instantiate(ghostPrefab, ghostList[ghostList_nextGhostIndex].getPositionVector(0),
                ghostList[ghostList_nextGhostIndex].GetRotationQuaternion(0));
            newGhost.AddComponent<GhostMovement>().Ghost = ghostList[ghostList_nextGhostIndex];
            ghostList_nextGhostIndex++;
        }
    }


    void Start()
    {
        isLevelCompleted = false;
        currentGhost = new Ghost();
        ghostList = new List<Ghost>();
        timerRecordGhostTransform = _TIMER_RECORD_GHOST_TRANSFORM_;
        ghostList_nextGhostIndex = 0;
    }


    private void LevelCompleted()
    {
        ghostList.Add(currentGhost);
    }


    private void RestartLevel()
    {
        currentGhost = new Ghost();
        generateNextGhost();
        isLevelCompleted = false;
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
//                Debug.Log("currentGhost: " + currentGhost.ToString());
//                Debug.Log("ghostList: " + ghostListToString());

                //            Debug.Log("currentGhostData getPositionVector: " + currentGhost.getPositionVector(0));
//                Debug.Log("Time.deltaTime: " + Time.time);
                timerRecordGhostTransform = _TIMER_RECORD_GHOST_TRANSFORM_;
            }
        }
    }
}