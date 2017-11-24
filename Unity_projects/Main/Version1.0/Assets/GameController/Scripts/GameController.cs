using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _MENU_SCENE_ID_ = 0; //to start menu scene on game over


    private static int _max_Collectable_Food_Count_ = 5;
    private static int collectableFoodCount;
    private static bool isLevelCompleted;
    private static bool isGameOver;

    private GameObject gameOverCanvas;


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
        get { return _max_Collectable_Food_Count_; }
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
        GhostGenerator.IsLevelCompleted = true;
    }

    private void GameOver()
    {
        GhostGenerator.IsGameOver = true;
        gameOverCanvas.SetActive(true);
    }


    public void GameOverPanelButtonClicked()
    {
        //TODO: open menu scene, destroy this scene and game object
        Destroy(GameObject.FindGameObjectWithTag("MainMenu"));

        SceneManager.LoadScene(_MENU_SCENE_ID_);
        Destroy(gameObject);
    }


    //____________________________________________
    void Start()
    {
        isLevelCompleted = false;
        isGameOver = false;
        gameOverCanvas = transform.GetChild(0).gameObject;
    }


    void Update()
    {
        if (collectableFoodCount == _max_Collectable_Food_Count_)
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