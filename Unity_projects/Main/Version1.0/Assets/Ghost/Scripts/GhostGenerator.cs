using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostGenerator : MonoBehaviour
{
    #region Parameters

    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private static bool isLevelCompleted;
    [SerializeField] private static bool isGameOver;
    [SerializeField] private int ghostList_newGhostIndex;
    [SerializeField] private float positionOffset;
    [SerializeField] private float _FREQUENCY_RECORD_GHOST_TRANSFORM_ = 0.5f; //const ?

    private List<Ghost> ghostList;
    private Ghost currentGhost;
    private float timerRecordGhostTransform;

    #endregion

    //_________________________________________________

    #region Singleton

    private static GhostGenerator ghostGeneratorInstance = null;
    
    private GhostGenerator()
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

    #endregion


    #region GetSet

    public float PositionOffset
    {
        get { return positionOffset; }
    }

    public static bool IsLevelCompleted
    {
        get { return isLevelCompleted; }
        set { isLevelCompleted = value; }
    }

    public static bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    #endregion


    //_________________________________________________

    #region Methods

    public float TimerRecordGhostTransform
    {
        get { return _FREQUENCY_RECORD_GHOST_TRANSFORM_; }
        set { _FREQUENCY_RECORD_GHOST_TRANSFORM_ = value; }
    }

    private String ghostListToString()
    {
        String result = "";
        foreach (Ghost ghost in ghostList)
        {
            result += ghost.ToString() + "\n|| -- ";
        }
        return base.ToString() + result;
    }

    private void generateNewGhost()
    {
        foreach (Ghost ghost in ghostList)
        {
            Debug.Log("INSTANCE :: " + ghost);
            GameObject newGhost = Instantiate(ghostPrefab, ghost.getPosition_i(0), ghost.getRotation_i(0));
            newGhost.AddComponent<GhostMovement>().Ghost = ghost;
        }
        ghostList_newGhostIndex++;
        //if (ghostList.Count > 0 && ghostList_newGhostIndex < ghostList.Count)
        //{
        //    Ghost ghostToInstantiate = ghostList[ghostList_newGhostIndex];
        //    //Debug.Log("Position : " + ghostToInstantiate.Positions.Count);
        //    GameObject newGhost = Instantiate(ghostPrefab, ghostToInstantiate.getPosition_i(0), ghostToInstantiate.getRotation_i(0));
        //    newGhost.AddComponent<GhostMovement>().Ghost = ghostToInstantiate;
        //    ghostList_newGhostIndex++;
        //}
    }

    private void LevelCompleted()
    {
        ghostList.Add(currentGhost);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        currentGhost = new Ghost();
        //generateNewGhost();
        isLevelCompleted = false;
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }

    #endregion


    //_________________________________________________
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isLevelCompleted = false;
        isGameOver = false;
        currentGhost = new Ghost();
        ghostList = new List<Ghost>();
        timerRecordGhostTransform = 0;
        ghostList_newGhostIndex = 0;
    }


    void Update()
    {
        if (isGameOver)
            GameOver();
        else
        {
            if (isLevelCompleted)
            {
                LevelCompleted();
                RestartLevel();
            }
            else
            {
                timerRecordGhostTransform += Time.deltaTime;
                if (timerRecordGhostTransform >= _FREQUENCY_RECORD_GHOST_TRANSFORM_)
                {
                    if (player == null)
                    {
                        player = GameObject.FindGameObjectWithTag("Player");
                        generateNewGhost();
                    }
                    currentGhost.addTransformData(player.transform);

//                Debug.Log(currentGhost + " : current ghost : " + currentGhost.getPosition_i(0) + " : player : " + player.transform.position);
                    //Debug.Log(currentGhost + " :: CURRENT GHOST :: " + currentGhost.Positions.Count);
                    timerRecordGhostTransform = 0;
                }
            }
        }
    }
}
