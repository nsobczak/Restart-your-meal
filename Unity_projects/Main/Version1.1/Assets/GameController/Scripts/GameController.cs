using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _MENU_SCENE_ID_ = 0; //to start menu scene on game over

    [SerializeField] private String _FOOD_TAG_ = "Food";
    private static int maxCollectableFoodCount;
    private static int collectableFoodCount;

    private static bool isLevelCompleted;
    private static bool isGameOver;
    private GameObject levelCompletedCanvas;
    private GameObject gameOverCanvas;

    private AudioSource audioSource;
    [SerializeField] private AudioClip levelCompletedAudioClip;

    private GameObject mainMenu;
    [SerializeField] private String _MAIN_MENU_TAG_ = "MainMenu";


    //___________________________________________

    #region singleton

    private static GameController gameControllerInstance = null;

    private GameController()
    {
        collectableFoodCount = 0;
    }

    public static GameController GetGameControllerInstance
    {
        get
        {
            if (gameControllerInstance == null)
                gameControllerInstance = new GameController();
            return gameControllerInstance;
        }
    }

    #endregion

    #region Getter/Setter

    public static int CollectableFoodCount
    {
        get { return collectableFoodCount; }
        set { collectableFoodCount = value; }
    }

    public static int MaxCollectableFood
    {
        get { return maxCollectableFoodCount; }
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


    //____________________________________________
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }


    private void LevelCompleted()
    {
        audioSource.Play();
        GhostGenerator.IsLevelCompleted = true;
        levelCompletedCanvas.SetActive(true);
    }


    private void GameOver()
    {
        GhostGenerator.IsGameOver = true;
        gameOverCanvas.SetActive(true);
        if (null != mainMenu) //to test when only scene "level01" is started
            mainMenu.GetComponent<AudioSource>().Stop();
    }

    //____________________________________________

    #region Button

    public void LevelCompletedPanelButtonClicked()
    {
        Debug.Log("LevelCompletedPanelButtonClicked");
        levelCompletedCanvas.SetActive(false);
        GhostGenerator.IsLevelRestarted = true;
        GhostGenerator.IsLevelCompleted = false;

        isLevelCompleted = false;
        collectableFoodCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void GameOverPanelButtonClicked()
    {
        //TODO: open menu scene, destroy this scene and game object
        Destroy(mainMenu);

        SceneManager.LoadScene(_MENU_SCENE_ID_);
        Destroy(gameObject);
    }

    #endregion


    //____________________________________________
    void Start()
    {
        isLevelCompleted = false;
        isGameOver = false;
        levelCompletedCanvas = transform.GetChild(0).gameObject;
        gameOverCanvas = transform.GetChild(1).gameObject;
        maxCollectableFoodCount = GameObject.FindGameObjectsWithTag(_FOOD_TAG_).Length;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = levelCompletedAudioClip;
        mainMenu = GameObject.FindGameObjectWithTag(_MAIN_MENU_TAG_);
    }


    void Update()
    {
        if (!isLevelCompleted)
        {
            if (collectableFoodCount == maxCollectableFoodCount)
            {
                isLevelCompleted = true;
                LevelCompleted();
            }
            else
            {
                if (isGameOver)
                    GameOver();
            }
        }
    }
}